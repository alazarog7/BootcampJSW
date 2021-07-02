using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class Boat: AquaticTransport
    {
        public override void Navigate()
        {
            Console.WriteLine($"The boat is navigating with {Speed} km/h of speed carrying {Capacity} people");
        }
    }
}
