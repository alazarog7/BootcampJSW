using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProject
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Phone Phone { get; set; }
    }

    public class Phone
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public string FixedNumber { get; set; }
    }
}
