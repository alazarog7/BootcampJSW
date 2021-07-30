using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Entities
{
    public class Rule
    {
        public Guid Id { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string ToFolder { get; set; }
    }
}
