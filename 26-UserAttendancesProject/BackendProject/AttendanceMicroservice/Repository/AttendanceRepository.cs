using AttendanceMicroservice.Database;
using AttendanceMicroservice.Entities;
using AttendanceMicroservice.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IAttendanceEvent _attendanceEvent;
        private readonly ILogger<AttendanceRepository> _logger;

        public AttendanceRepository(IApplicationDbContext context, IAttendanceEvent attendanceEvent, ILogger<AttendanceRepository> logger)
        {
            _context = context;
            _attendanceEvent = attendanceEvent;
            _logger = logger;
        }

        public async Task<Attendance> Create(Attendance attendance)
        {
            attendance.Id = Guid.NewGuid();

            RedisKey key = new RedisKey($"attendance:{attendance.Id}:user:{attendance.IdUser}");
            _context.Database.HashSet(key, attendance.ToHashEntries());

            Attendance attendanceRetrieve = _context.Database.HashGetAll(key).ConvertFromRedis<Attendance>();
            _logger.LogInformation("Creando evento");
            await _attendanceEvent.AttendanceEventGeneration(attendance.IdUser, 1);
            _logger.LogInformation("Finalizando evento");

            return attendanceRetrieve;
        }

        public async Task Delete(Guid Key)
        {
            
            string key = _context.Database.Scan(new RedisKey($"attendance:{Key}:*")).FirstOrDefault();
            
            _logger.LogInformation($"{key}");
            if (key is not null)
            {
                Attendance attendance = _context.Database.HashGetAll(new RedisKey(key)).ConvertFromRedis<Attendance>();
                _logger.LogInformation($"{attendance.IdUser}");
                _context.Database.KeyDelete(key);
                await _attendanceEvent.AttendanceEventGeneration(attendance.IdUser, -1);
            }
        }

        public void DeleteAttendancesByUserId(int UserId)
        {
            List<string> Keys = _context.Database.Scan(new RedisKey($"attendance:*:user:{UserId}"));
            _logger.LogInformation(string.Join("\n",Keys.ToArray()));
            Keys.ForEach(key => {
                _logger.LogInformation($"removing  {key}");
                this._context.Database.KeyDelete(new RedisKey(key));
            });
        }

        public Attendance GetAttendanceByKey(Guid Key)
        {
            string key = _context.Database.Scan(new RedisKey($"attendance:{Key}:*")).FirstOrDefault();
            if (key is not null)
            {
                Attendance attendance = _context.Database.HashGetAll(new RedisKey(key)).ConvertFromRedis<Attendance>();
                return attendance;
            }

            return null;
        }

        public List<Attendance> GetAttendancesById(int UserId)
        {
            List<string> Keys = _context.Database.Scan(new RedisKey($"attendance:*:user:{UserId}"));
            List<Attendance> UserAttendance = new List<Attendance>();
            Keys.ForEach(key => {
                UserAttendance.Add(_context.Database.HashGetAll(key).ConvertFromRedis<Attendance>());
            });

            return UserAttendance;
        }
    }
}
