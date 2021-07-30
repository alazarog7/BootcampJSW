using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Entities
{
    public class Mail
    {
        public string Ip { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return $"To: {To} \n" +
                   $"From: {From} \n" +
                   $"When: {Date} \n" +
                   $"Subject: {Subject} \n" +
                   $"Body:\n {Body} \n";
        }
    }
}
