using System.Threading.Tasks;

namespace AttendanceMicroservice.Events
{
    public interface IAttendanceEvent
    {
        Task AttendanceEventGeneration(int idUser, int attendanceFlag);
    }
}