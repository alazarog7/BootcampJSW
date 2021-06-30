using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person[] people = {
            //	new Person{Name="Alejandro"},
            //	new Person{Name="Pepe"},
            //	new Person{Name="Juan"},
            //	new Person{Name="Carlos"},
            //	new Person{Name="Maria"}
            //};

            //Console.WriteLine("Initial list of people:");

            //foreach (var person in people)
            //{
            //	Console.WriteLine($"{person.Name}");
            //}

            //Console.WriteLine("Use Person's IComparable implementation to sort: ");

            //Array.Sort(people, new PersonComparer());
            ////people = people.OrderByDescending(c => c.Edad).ToArray();

            ////Array.Sort(people, delegate (Person p1, Person p2) { return p2.Edad.CompareTo(p1.Edad); });

            //foreach (var person in people)
            //{
            //	Console.WriteLine($"{person.Name}");
            //}

            IPlayable dvdPlayer = new Mp3Player();
            dvdPlayer.Stop();

        }
    }

    public interface IPlayable
    {
        public void Stop() {
            Console.WriteLine("Default DVD player is stop");
        }
        void Play();
        void Pause();
    }

    public class DvdPlayer : IPlayable
    {


        public void Pause()
        {
            Console.WriteLine("DVD player is in pause");
        }

        public void Play()
        {
            Console.WriteLine("DVD player is playing");
        }

        public void Stop()
        {
            Console.WriteLine("DVD player is stop");
        }
    }

    public class Mp3Player : IPlayable
    {


        public void Pause()
        {
            Console.WriteLine("DVD player is in pause");
        }

        public void Play()
        {
            Console.WriteLine("DVD player is playing");
        }
    }


    //public class Person : IComparable<Person>
    //{
    //	public string Name { get; set; }

    //	//public int Edad { get; set; }

    //	public int CompareTo(Person other)
    //	{
    //		return this.Name.CompareTo(other.Name);
    //	}

    //	//public override string ToString()
    //	//{
    //	//	return $"[ Nombre = { this.Name }, Edad = {this.Edad} ] ";
    //	//}

    //}


    public class Person
	{
		public string Name { get; set; }
	}


    class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
			return x.Name.CompareTo(y.Name);
        }
    }

}
