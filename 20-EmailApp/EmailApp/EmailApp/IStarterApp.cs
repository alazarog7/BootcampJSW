using EmailApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp
{
    public interface IStarterApp
    {
        public void Start();
        public void Route(String controller);
    }
}
