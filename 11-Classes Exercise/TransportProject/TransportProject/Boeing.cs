using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class Boeing: AirTransport
    {
        public override void Fly()
        {
            Console.WriteLine($"Boeing is flying at {Height} km of height, with {Speed} km/h of speed carrying {Capacity} people");
        }

        public override void Land()
        {
            Console.WriteLine("Boeing is landing");
        }

    }
}
