using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Notes { get; set; }
        public int IdUser { get; set; }
        public int IdUserCreatorRegistry { get; set; }
    }
}
