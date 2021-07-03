using System;

namespace TransportProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------- Boeing
            Console.WriteLine();
            Console.WriteLine("---------- Boeing");
            Console.WriteLine();

            Boeing boeing = new Boeing() { 
                Capacity = 110,
                Speed = 300,
                MaxHeight = 10
            };

            boeing.Fly();
            boeing.Land();

            //----------- ElectricFlyingCar
            Console.WriteLine();
            Console.WriteLine("---------- ElectricFlyingCar");
            Console.WriteLine();

            ElectricFlyingCar electricFlyingCar = new ElectricFlyingCar() { 
                Speed = 100,
                Capacity = 10,
                Wheels = 4,
                MaxHeight = 1200
            };

            electricFlyingCar.Handle();
            
            Console.WriteLine("Time to fly ...");
            electricFlyingCar.Fly();
            electricFlyingCar.Land();

            //----------- Toyota
            Console.WriteLine();
            Console.WriteLine("---------- Toyota");
            Console.WriteLine();

            Toyota toyota = new Toyota() {
                Capacity = 4,
                Wheels = 4,
                Speed = 100
            };
            
            toyota.Handle();

            //---------- Boat
            Console.WriteLine();
            Console.WriteLine("---------- Boat");
            Console.WriteLine();
            
            Boat boat = new Boat() { 
                Capacity = 10,
                Speed = 100
            };

            boat.Navigate();
        }
    }
}
