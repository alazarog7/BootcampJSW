using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.Unique.Name = "pepe";
            //Person.Unique.LastName = "pepe";
            Console.WriteLine(Person.Unique.Name);
            //Console.WriteLine(Person.Unique.LastName);
        }
    }

    class Person : UniqueInstance<Person>
    {
        public string Name;
    }

    class UniqueInstance<T> where T: new()
    {
        public static T Unique = Unique !=null ? Unique : new(); // reference to a instance of a 
    }
}
