using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class AquaticTransport: Transport
    {
        public virtual void Navigate()
        {
            Console.WriteLine("Navigating ...");
        }
    }
}
