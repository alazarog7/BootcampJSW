using EmailApp.DB;
using EmailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DataSource _data;
        private readonly ISecurityService _securityService;

        public ProfileService(DataSource data, ISecurityService securityService) 
        {
            _data = data;
            _securityService = securityService;
        }

        public void Create(User user)
        {
            if ( ! _securityService.Verify(user.Username) )
            {
                Profile profile = new Profile()
                {

                    User = user,
                    Mails = new Dictionary<Guid, Mail>() { },
                    Folders = new Dictionary<string, List<Guid>>
                    {
                        { "inbox", new List<Guid>() { } },
                        { "sent", new List<Guid>() { } }
                    },
                    Rules = new List<Rule>()
                };
                
                _data.Users.Add(profile);
                _data.CurrentUser = profile;
            }
        }

        public User GetCurrent()
        {
            return _data.CurrentUser?.User;
        }
    }
}
