using EmailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.DB
{
    public class DataSource
    {
        public HashSet<Profile> Users { get; set; } = new HashSet<Profile>()
        {
            new Profile()
            {
                User = new User{ Username = "ale", FullName = "Alejandro Lazaro Gutierrez" },
                Mails = new Dictionary<Guid, Mail>()
                {
                    {
                        new Guid("4d73ca97-c480-485b-b0e7-b8610881f4c2"),
                        new Mail()
                        {
                            Ip = "127.0.0.1",
                            Date = new DateTime(2007,12,12),
                            From = "alazarog7@gmail.com",
                            To = "alazarog7@gmail.com",
                            CC = "",
                            Subject = "Trabajo Practico",
                            Body = "Debes terminar el trabajo"
                        }
                    }
                    
                },
                Folders = new Dictionary<string, List<Guid>>()
                {
                    {"inbox", new List<Guid>() },
                    {"sent", new List<Guid>(){ new Guid("4d73ca97-c480-485b-b0e7-b8610881f4c2")} }
                },
                Rules = new List<Rule>()
            }
        };


        public Profile CurrentUser { get; set; }
    }
}
