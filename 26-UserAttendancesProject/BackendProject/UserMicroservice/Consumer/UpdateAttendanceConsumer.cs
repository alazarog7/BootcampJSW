using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferEntities;
using UserMicroservice.Db;
using UserMicroservice.Entities;

namespace UserMicroservice.Consumer
{
    public class UpdateAttendanceConsumer : IConsumer<UpdateAttendance>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UpdateAttendanceConsumer> _logger;

        public UpdateAttendanceConsumer(ApplicationDbContext context, ILogger<UpdateAttendanceConsumer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAttendance> context)
        {
            _logger.LogInformation($"Recibiendo {context.Message.IdUser} {context.Message.AttendanceFlag}");
            User user = _context.Users.Where(user => user.Id == context.Message.IdUser).FirstOrDefault();
            
            if(user is not null)
            {
                user.TotalAttendance += context.Message.AttendanceFlag;
                _context.SaveChanges();
            }
        }
    }
}
