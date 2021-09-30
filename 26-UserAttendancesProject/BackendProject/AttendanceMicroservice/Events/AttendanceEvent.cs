using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferEntities;

namespace AttendanceMicroservice.Events
{
    public class AttendanceEvent : IAttendanceEvent
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AttendanceEvent> _logger;

        public AttendanceEvent(IBus bus, IConfiguration configuration, ILogger<AttendanceEvent> logger)
        {
            _bus = bus;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task AttendanceEventGeneration(int idUser, int attendanceFlag)
        {
            Uri uri = new Uri($"rabbitmq://localhost/AttendanceEvent");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send( new UpdateAttendance{ IdUser = idUser, AttendanceFlag = attendanceFlag });
            _logger.LogInformation($"Se envio {idUser} a AttendanceEvent");
        }
    }
}
