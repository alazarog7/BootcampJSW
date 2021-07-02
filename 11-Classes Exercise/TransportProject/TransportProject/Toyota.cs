using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class Toyota: LandTransport
    {
        public override void Handle()
        {
            Console.WriteLine($"Toyota car of {Wheels} wheels is running with {Speed} km/h of speed carrying {Capacity} people");
        }
    }
}
