using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsability
{
    public interface Handler
    {
        public Handler Handler { get; set; }
        public void Process(File file);
    }
}
