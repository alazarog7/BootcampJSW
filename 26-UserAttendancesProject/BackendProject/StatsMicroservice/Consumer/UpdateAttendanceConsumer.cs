using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferEntities;

namespace StatsMicroservice.Consumer
{
    public class UpdateAttendanceConsumer : IConsumer<UpdateAttendance>
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UpdateAttendanceConsumer> _logger;

        public UpdateAttendanceConsumer(IBus bus, IConfiguration configuration, ILogger<UpdateAttendanceConsumer> logger)
        {
            _bus = bus;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAttendance> context)
        {
            var attendance = context.Message;
            _logger.LogInformation($"Recibiendo {context.Message.IdUser} {context.Message.AttendanceFlag}");
            Uri uri = new Uri($"{_configuration.GetConnectionString("rabitmq")}/AttendanceEventUpdate");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(attendance);
        }
    }
}
