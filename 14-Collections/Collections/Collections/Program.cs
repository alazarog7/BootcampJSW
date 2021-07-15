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


            //var arraylist = new ArrayList();

            //int[] arra1 = { 1, 2, 2, 3, 45, 5 };

            //Queue queue = new Queue();

            //queue.Enqueue("Data");
            //arraylist.Add(null);
            //arraylist.AddRange(arra1);
            //arraylist.AddRange(queue);
            //arraylist.Remove(null);
            //Console.WriteLine(string.Join(",", arraylist));

            //var student = new List<Student>()
            //{
            //    new Student{ Id = 1, Name ="Jose"},
            //    new Student{ Id = 2, Name ="Pedro"},
            //};


            //string[] cities = new string[] { "la paz", "cochabamba" };

            //var popularCities = new List<string>();

            //popularCities.AddRange(cities);

            //var favouriteCities = new List<string>();

            //favouriteCities.AddRange(popularCities);

            //Console.WriteLine(popularCities[0]);

            //popularCities.ForEach(Console.WriteLine);


            ////Linq

            //var result = from s in student
            //             where s.Name == "Pedro"
            //             select s;



            //result.ToList().ForEach(s => Console.WriteLine(s.Id + " , " + s.Name));

            //// Contains
            //Console.WriteLine(popularCities.Contains("tarija"));


            //SortedList<int, string> numberNames = new SortedList<int, string>();


            //numberNames.Add(1, "maria");
            //numberNames.Add(4, "marlene");
            //numberNames.Add(3, "madelene");
            //numberNames.Add(2, "mariam");

            //foreach (KeyValuePair<int, string> value in numberNames)
            //{
            //    Console.WriteLine(value.Key + "" + value.Value);
            //}

            //numberNames.Add(5, "pedro");
            //numberNames.Add(6, "marco");

            //foreach (var value in numberNames)
            //{
            //    Console.WriteLine(value.Key + "" + value.Value);
            //}

            //Console.WriteLine(numberNames[1]);


            Dictionary<int, string> keyName = new Dictionary<int, string>();

            keyName.Add(3, "three");
            keyName.Add(2, "two");
            keyName.Add(1, "one");

            foreach (KeyValuePair<int, string> value in keyName)
            {
                Console.WriteLine(value.Key + " , " + value.Value);
            }

            var cities = new Dictionary<string, string>()
            {
                {"UK", "London, Manchester, Birmingham" },
                {"USA", "Chicago, NY, Washington" },
                {"India", "Mumbai, New Delhi, Pune" }
            };

            foreach(KeyValuePair<string, string> value in cities)
            {
                Console.WriteLine(value.Key + " , " + value.Value);
            }

            Console.WriteLine(cities["UK"]);

            if (cities.ContainsKey("UK"))
            {
                Console.WriteLine("Contains");
            } 
            else
            {
                Console.WriteLine("No Contains");
            }
            
            string result;

            if(cities.TryGetValue("UK", out result))
            {
                Console.WriteLine("Result = " + result);
            }

            for(int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine($"{cities.ElementAt(i).Key} {cities.ElementAt(i).Value}");
            }

            // Update a dictionary

            cities["BOL"] = "La Paz, Cochabamba";

            Hashtable hashtable = new Hashtable();
            hashtable.Add(3, "three");
            hashtable.Add(2, "two");
            hashtable.Add(1, "one");

            Hashtable hashtable2 = new Hashtable()
            {
                {1, "one" },
                {2, "two" },
                {3, "three" }
            };

            foreach (DictionaryEntry v in hashtable2)
            {
                Console.WriteLine(v.Key + " " + v.Value);
            }

            Hashtable ht = new Hashtable(keyName);


            var cities3 = new Hashtable()
            {
                {"UK", "London, Manchester, Birmingham" },
                {"USA", "Chicago, NY, Washington" },
                {"India", "Mumbai, New Delhi, Pune" }
            };

            string citiesUK = (string)cities3["UK"]; // para el caso de hashtable es necesario hacer casting

            string citiesUSA = (string)cities3["USA"];

            Console.WriteLine(citiesUSA);
            Console.WriteLine(citiesUK);


            Stack<int> myStack = new Stack<int>();

            myStack.Push(5);
            myStack.Push(2);
            myStack.Push(34);
            myStack.Push(1);
            myStack.Push(8);

            Console.WriteLine(myStack.Pop());

            foreach(var e in myStack)
            {
                Console.WriteLine(e);
            }

            while(myStack.Count > 0)
            {
                Console.WriteLine("1-- ");
                Console.WriteLine(myStack.Pop());
            }

            while (myStack.Count > 0)
            {
                Console.WriteLine("2-- ");
                Console.WriteLine(myStack.Pop());
            }

        }

    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
