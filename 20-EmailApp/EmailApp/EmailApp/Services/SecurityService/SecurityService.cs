using EmailApp.DB;
using EmailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly DataSource _data;

        public SecurityService(DataSource data)
        {
            _data = data;
        }

        public void Authenticate(string username)
        {
            Profile profile = _data.Users.Where(x => x.User.Username.Equals(username)).FirstOrDefault();
            _data.CurrentUser = profile;
        }

        public void RemoveAuthetication()
        {
            _data.CurrentUser = null;
        }

        public bool Verify(string username)
        {
            Profile profile = _data.Users.Where(x => x.User.Username.Equals(username)).FirstOrDefault();
            return profile != null;
        }
    }
}
