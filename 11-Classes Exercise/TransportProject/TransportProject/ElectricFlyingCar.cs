using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProject
{
    public class ElectricFlyingCar : LandTransport 
    {
        public AirTransport FlyingOption { get; set; }

        public override void Handle()
        {
            Console.WriteLine($"A modern car of {Wheels} wheels is running with {Speed} km/h of speed carrying {Capacity} people");
        }

    }
}
