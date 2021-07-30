using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Entities
{
    public class Profile
    {
        public User User { get; set; }
        public Dictionary<Guid, Mail> Mails { get; set; }
        public Dictionary<string, List<Guid>> Folders { get; set; }
        public List<Rule> Rules { get; set; }


        public override bool Equals(object other)
        {
            Profile compareObj = other as Profile;

            if (compareObj == null)
            {
                return false;
            }

            return User.Username.Equals(compareObj.User.Username);
        }

        public override int GetHashCode()
        {
            return User.Username.GetHashCode();
        }
    }
}
