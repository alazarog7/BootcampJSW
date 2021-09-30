using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Aggregates.UserAggregates
{
    public class UserAggregator
    {
        public string nickname { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int totalAttendance { get; set; }
        public List<Attendance> attendances { get; set; } = new List<Attendance>();
    }
}
