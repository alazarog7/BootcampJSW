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

            Boeing boeing = new Boeing();
            boeing.Capacity = 110;
            boeing.Speed = 300; //km/h
            boeing.Height = 10; //km
            boeing.Fly();
            boeing.Land();

            //----------- ElectricFlyingCar
            Console.WriteLine();
            Console.WriteLine("---------- ElectricFlyingCar");
            Console.WriteLine();

            ElectricFlyingCar electricFlyingCar = new ElectricFlyingCar();
            electricFlyingCar.Speed = 100; // km/h
            electricFlyingCar.Capacity = 10;
            electricFlyingCar.Wheels = 4;

            electricFlyingCar.FlyingOption = new AirTransport();
            electricFlyingCar.FlyingOption.Height = 100;
            electricFlyingCar.FlyingOption.Fly();
            electricFlyingCar.FlyingOption.Land();

            electricFlyingCar.Handle();

            //----------- Toyota
            Console.WriteLine();
            Console.WriteLine("---------- Toyota");
            Console.WriteLine();

            Toyota toyota = new Toyota();
            toyota.Capacity = 4;
            toyota.Wheels = 4;
            toyota.Speed = 100; // km/h
            toyota.Handle();

            //---------- Boat
            Console.WriteLine();
            Console.WriteLine("---------- Boat");
            Console.WriteLine();
            Boat boat = new Boat();
            boat.Capacity = 10;
            boat.Speed = 100; //km/h
            boat.Navigate();
            

        }
    }
}
