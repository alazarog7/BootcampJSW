using EmailApp.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Controller
{
    public abstract class BaseController
    {

        public IStarterApp main { get; }
        protected BaseController(IStarterApp main)
        {
            this.main = main;
        }

        public abstract void Start();
    }
}

