using AttendanceMicroservice.Database;
using AttendanceMicroservice.DataTransferObject;
using AttendanceMicroservice.Entities;
using AttendanceMicroservice.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Controllers
{
    [ApiController]
    [Route("attendances")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceController( IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AttendanceCreation attendanceCreation)
        {
            int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);

            Attendance attendance = _mapper.Map<Attendance>(attendanceCreation);
            attendance.IdUserCreatorRegistry = userId;
            attendance = await _attendanceRepository.Create(attendance);

            return Ok(attendance);
        }

        [HttpDelete("{Key:guid}")]
        public IActionResult Delete(Guid Key)
        {
            int userLoggedId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);
            
            Attendance attendanceRegistry = _attendanceRepository.GetAttendanceByKey(Key);
            
            if(attendanceRegistry is not null && attendanceRegistry.IdUserCreatorRegistry == userLoggedId)
            {
                _attendanceRepository.Delete(Key);
                return NoContent();
            }

            return Unauthorized();
        }

        [HttpGet("{UserId:int}")]
        public IActionResult GetAssistanceByUserId(int UserId)
        {
            List<Attendance> UserAttendance = _attendanceRepository.GetAttendancesById(UserId);

            return Ok(_mapper.Map<List<AttendanceResponse>>(UserAttendance));
        }
    }

   
}
