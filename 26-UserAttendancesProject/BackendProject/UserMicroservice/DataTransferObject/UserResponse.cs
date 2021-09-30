using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.DataTransferObject
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TotalAttendance { get; set; }
    }
}
