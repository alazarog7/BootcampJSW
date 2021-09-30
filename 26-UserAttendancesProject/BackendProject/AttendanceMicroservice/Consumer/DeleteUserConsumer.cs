using AttendanceMicroservice.Database;
using AttendanceMicroservice.Repository;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferEntities;

namespace AttendanceMicroservice.Consumer
{
    public class DeleteUserConsumer : IConsumer<RemoveUser>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILogger<DeleteUserConsumer> _logger;

        public DeleteUserConsumer(IAttendanceRepository attendanceRepository, ILogger<DeleteUserConsumer> logger)
        {
            _attendanceRepository = attendanceRepository;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<RemoveUser> context)
        {
            _logger.LogInformation($"Removing user attendances {context.Message.UserId}");
            _attendanceRepository.DeleteAttendancesByUserId(context.Message.UserId);
        }
    }
}
