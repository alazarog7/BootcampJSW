using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //var arrayList = new ArrayList(); // it is more expensive than generics
            //arrayList.Add(1);
            //arrayList.Add(2);
            //arrayList.Add(3);
            //arrayList.Add("Alejandro");

            //Console.WriteLine(arrayList.GetType());

            //Console.WriteLine(string.Join(",", arrayList.ToArray()));


            var arraylist = new ArrayList();

            int[] arra1 = { 1, 2, 2, 3, 45, 5 };

            Queue queue = new Queue();

            queue.Enqueue("Data");
            arraylist.Add(null);
            arraylist.AddRange(arra1);
            arraylist.AddRange(queue);
            arraylist.Remove(null);
            Console.WriteLine(string.Join(",", arraylist));

            var student = new List<Student>()
            {
                new Student{ Id = 1, Name ="Jose"},
                new Student{ Id = 2, Name ="Pedro"},
            };


            string[] cities = new string[] { "la paz", "cochabamba" };

            var popularCities = new List<string>();

            popularCities.AddRange(cities);

            var favouriteCities = new List<string>();

            favouriteCities.AddRange(popularCities);

            Console.WriteLine(popularCities[0]);

            popularCities.ForEach(Console.WriteLine);


            //Linq

            var result = from s in student
                         where s.Name == "Pedro"
                         select s;



            result.ToList().ForEach(s => Console.WriteLine(s.Id + " , " + s.Name));

            // Contains
            Console.WriteLine(popularCities.Contains("tarija"));


            SortedList<int, string> numberNames = new SortedList<int, string>();


            numberNames.Add(1, "maria");
            numberNames.Add(4, "marlene");
            numberNames.Add(3, "madelene");
            numberNames.Add(2, "mariam");

            foreach (KeyValuePair<int, string>  value in numberNames)
            {
                Console.WriteLine(value.Key + "" + value.Value);
            }


        }

    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
