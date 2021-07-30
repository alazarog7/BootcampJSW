using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public interface ISecurityService
    {
        public void Authenticate(string username);
        public bool Verify(string username);
        public void RemoveAuthetication();
    }
}
