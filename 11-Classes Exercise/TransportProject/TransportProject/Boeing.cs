using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class Boeing: Transport, IAirTransport
    {
        public decimal MaxHeight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Boeing is flying at {MaxHeight} km of height, with {Speed} km/h of speed carrying {Capacity} people");
        }

        public void Land()
        {
            Console.WriteLine("Boeing is landing");
        }

    }
}
