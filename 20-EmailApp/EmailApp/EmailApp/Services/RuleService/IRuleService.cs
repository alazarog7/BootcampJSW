using EmailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services.RuleService
{
    public interface IRuleService
    {
        void Create(Rule rule);

        List<Rule> GetAll();

        void Delete(Guid id);

        string VerifyRule(Mail mail, String destinatary);
    }
}
