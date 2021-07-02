using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class AirTransport : Transport
    {
        public float Height { get; set; }

        public virtual void Fly()
        {
            Console.WriteLine($"Flying at {Height} km of height, with speed of {Speed} km/h");
        }

        public virtual void Land()
        {
            Console.WriteLine("Landing ...");
        }
    }
}
