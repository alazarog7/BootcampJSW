using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.DataTransferObject
{
    public class AttendanceCreation
    {
        public string Start { get; set; }
        public string End { get; set; }
        public string Notes { get; set; }
        public int IdUser { get; set; }
    }
}
