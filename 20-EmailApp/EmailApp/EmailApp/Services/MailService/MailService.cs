using EmailApp.DB;
using EmailApp.Entities;
using EmailApp.Services.RuleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    

    public class MailService : IMailService
    {
        private DataSource _data;
        private IRuleService _ruleService;
        public MailService(DataSource data, IRuleService ruleService)
        {
            _data = data;
            _ruleService = ruleService;
        }

        public void Create(Mail mail)
        {
            Mail newMail= new Mail
            {
                Ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(0).ToString(),
                From = _data.CurrentUser.User.Username,
                To = mail.To,
                Date = DateTime.Now,
                CC = mail.CC,
                Subject = mail.Subject,
                Body = mail.Body
            };

            Guid id = Guid.NewGuid();
            _data.CurrentUser.Mails.Add(id , newMail);

            _data.CurrentUser.Folders["sent"].Add(id);

            Send(new Tuple<Guid, Mail>(id,newMail));

            _data.Users.Add(_data.CurrentUser);
            
        }

        public void Delete(Guid id, string folderName)
        {
            _data.CurrentUser.Folders[folderName].Remove(id);
            _data.CurrentUser.Mails.Remove(id);

            _data.Users.Add(_data.CurrentUser);
        }

        public Dictionary<Guid, Mail> GetByFolder(string folderName)
        {
            var indexes = _data.CurrentUser.Folders[folderName];

            Dictionary<Guid, Mail> selectedMails = new Dictionary<Guid, Mail>();

            indexes.ToList().ForEach( e => {
                selectedMails.Add(e , _data.CurrentUser.Mails[e]);
            });

            return selectedMails;
        }

        public Mail GetById(Guid id)
        {
            return _data.CurrentUser.Mails[id]; 
        }

        public void Move(string folderOrg, string folderDest, Guid id)
        {
            _data.CurrentUser.Folders[folderOrg].Remove(id);
            _data.CurrentUser.Folders[folderDest].Add(id);
            _data.Users.Add(_data.CurrentUser);
        }

        public void Send(Tuple< Guid, Mail > mail)
        {
            List<string> usernames = new List<string>() { mail.Item2.To };

            usernames.AddRange(mail.Item2.CC.Split(";").ToList());
            
            foreach(string username in usernames)
            {
                var user =_data.Users.Where(e => e.User.Username == username).FirstOrDefault();

                if( user != null)
                {
                    //TODO VALIDATE RULES

                    string folder = _ruleService.VerifyRule(mail.Item2,username);

                    user.Mails.Add(mail.Item1, mail.Item2);
                    user.Folders[folder != ""? folder : "inbox"].Add(mail.Item1);
                }
            }

        }


    }
}
