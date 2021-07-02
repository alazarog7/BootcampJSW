using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class LandTransport : Transport
    {
        public int Wheels { get; set; }

        public virtual void Handle()
        {
            Console.WriteLine("Vehicle is running....");
        }
    }
}
