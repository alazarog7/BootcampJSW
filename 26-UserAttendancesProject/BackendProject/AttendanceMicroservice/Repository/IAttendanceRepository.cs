using AttendanceMicroservice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Repository
{
    public interface IAttendanceRepository
    {
        Task<Attendance> Create(Attendance attendance);
        Task Delete(Guid Key);
        void DeleteAttendancesByUserId(int UserId);
        List<Attendance> GetAttendancesById(int UserId);
        Attendance GetAttendanceByKey(Guid Key);
    }
}
