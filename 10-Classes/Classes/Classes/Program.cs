using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee juan = new Employee()
            //{
            //    Name = "juan",
            //    DateOfBirth = new DateTime(1990, 7, 28)
            //};

            //juan.EmployeeCode = "111a";
            //juan.HireDate = new DateTime(2017, 12, 12);

            //Console.WriteLine($"{juan.Name} was hored on {juan.HireDate:dd/MM/yyyy}"); // stream interpolation

            ////juan.WriteInformation();

            //Console.WriteLine(juan);

            ElectricFlyingCar car = new ElectricFlyingCar();

        }
    }

    public abstract class Transport
    {
        public int Speed { get; set; }

        public int Capacity { get; set; }
    }

    public class AirTransport: Transport
    { 
        public int MaxHeight { get; set; }

        //public void Fly()
        //{
        //    Console.WriteLine("Flying");
        //}

        //public void Land()
        //{
        //    Console.WriteLine("Landing");
        //}
    }

    public interface IAirTransport
    {
        public static int MaxHeight;
        public void Fly();

        public void Land();
    }

    public class LandTransport: Transport
    {
        public int Wheels { get; set; }
    }

    public interface ILandTransport
    {
        public void Driving();
    }

    public interface IAquaticTranport
    {
        public void Navigate();
    }

    public class ElectricFlyingCar : LandTransport, IAirTransport, ILandTransport
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }

        public void Land()
        {
            Console.WriteLine("Landing");
        }

        public void Driving()
        {
            Console.WriteLine("Driving in Land");
        }
    }
   


    public class Singer
    {
        public virtual void Sing()
        {
            Console.WriteLine("Singing....");
        }
    }

    public class LadyGaga: Singer
    {
        public sealed override void Sing()
        {
            Console.WriteLine("Lady Gaga is singing");
        }
    }

    partial class A: LadyGaga
    {

        public string Name { get; set; }
       
    }

    partial class A : LadyGaga
    {

        public string LastName { get; set; }

    }


    public sealed class SealedClass // Evita que otras clases de esta clase
    {

    }


    public class Employee: Person
    {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} and hired on:{HireDate:dd/MM/yyyy}";
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{Name} was born on a {DateOfBirth.DayOfWeek}";
        }
        public virtual void WriteInformation()
        {
            Console.WriteLine("parent");
        }
    }

}
