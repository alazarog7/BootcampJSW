using EmailApp.DB;
using EmailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services.RuleService
{
    public class RuleService: IRuleService
    {
        private DataSource _data;

        public RuleService(DataSource data)
        {
            _data = data;
        }

        public void Create(Rule rule)
        {
            _data.CurrentUser.Rules.Add(rule);
            _data.Users.Add(_data.CurrentUser);
        }

        public void Delete(Guid id)
        {
            Rule rule = _data.CurrentUser.Rules.Where(e => e.Id == id).FirstOrDefault();
            _data.CurrentUser.Rules.Remove(rule);
            _data.Users.Add(_data.CurrentUser);
        }

        public List<Rule> GetAll()
        {
            return _data.CurrentUser.Rules;
        }

        public string VerifyRule(Mail mail, string destinatary)
        {
            string folderName = "";

            _data.Users
                .Where(e => e.User.Username == destinatary )
                .FirstOrDefault()
                .Rules
                .ForEach(r => { 
                
                    if(mail.From.Equals(r.FromEmail) || mail.Subject.Contains(r.Subject) || mail.Body.Equals(r.Subject))
                    {
                        folderName = r.ToFolder;
                    }
            
                });

            return folderName;
        }
    }
}
