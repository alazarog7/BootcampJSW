using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferEntities;

namespace UserMicroservice.Events
{
    public class UserEvent : IUserEvent
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserEvent> _logger;

        public UserEvent(IBus bus, IConfiguration configuration, ILogger<UserEvent> logger)
        {
            _bus = bus;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task DeleteUserEvent(int IdUser)
        {
            Uri uri = new Uri($"rabbitmq://localhost/DeleteUserEvent");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new RemoveUser { UserId = IdUser });
            _logger.LogInformation($"Se envio {IdUser} a DeleteUserEvent");
        }
    }
}
