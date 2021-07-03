using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class ElectricFlyingCar : Transport, IAirTransport, ILandTransport
    {
        public decimal MaxHeight { get; set; }
        public int Wheels { get; set; }

        public void Handle()
        {
            Console.WriteLine($"A modern car of {Wheels} wheels is running with {Speed} km/h of speed carrying {Capacity} people");
        }

        public void Fly()
        {
            Console.WriteLine($"Flying at {MaxHeight} km of height, with speed of {Speed} km/h carrying {Capacity} people");
        }

        public void Land()
        {
            Console.WriteLine("Landing ...");
        }
    }
}
