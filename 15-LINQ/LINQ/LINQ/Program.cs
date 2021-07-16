using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //var names = new string[] { "Michael", "Maria", "Joel", "Bob" };

            ///var query = names.Where(names => names.Length > 3);
            ///.Where(new Func<string, bool>(MoreThanFour));
            //var query = names
            //                .Where(MoreThanFour)
            //                .OrderBy(name => name.Length)
            //                .ThenBy(name => name);

            //foreach (string e in query)
            //{
            //    Console.WriteLine(e);
            //}

            //var filteredException = GetExceptions().OfType<ArithmeticException>();

            //foreach (var e in filteredException)
            //{
            //    Console.WriteLine(e);
            //}

            //var group1 = new string[] { "Maria", "Maria", "Joel", "Mario" };
            //var group2 = new string[] { "Oscar", "Pepe", "Juan", "Bertha" };
            //var group3 = new string[] { "Carl", "Mario" };

            //ShowArray(group1, "Group 1");
            //ShowArray(group2, "Group 2");
            //ShowArray(group3, "Group 3");

            //ShowArray(group1.Distinct(), "group1.Distinct()");
            //ShowArray(group1.Union(group3), "group1.Union(group3)");
            //ShowArray(group1.Concat(group3), "group1.Concat(group3)");
            //ShowArray(group1.Intersect(group3), "group1.Intersect(group3)");

            //ShowArray(group1.Except(group3), "group1.Intersect(group3)");
            //ShowArray(group1.Zip(group2, (p1, p2) => $"{p1} matched With {p2}"), "group1.Intersect(group3)");

            //var students = new string[] { "Michael", "Pam", "Jim", "Dwight", "Anglea", "Kevin", "Toby", "Creed" };

            //var query2 = (from student in students
            //              where MoreThanFour(student)
            //              orderby student.Length, student
            //              select student)
            //             .Skip(2)
            //             .Take(3);

            //foreach (var e in query2)
            //{
            //    Console.WriteLine(e);
            //}



            //var watch = new Stopwatch();

            //Console.WriteLine("Press enter");
            //Console.ReadLine();
            //watch.Start();
            //IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
            ////var squares = numbers.AsParallel().Select(number => number * number).ToArray();
            //var squares = numbers.Select(number => number * number).ToArray();
            //watch.Stop();
            //Console.WriteLine("{0:#,##0} miliseconds", arg0: watch.ElapsedMilliseconds);

            List<Product> products = new List<Product>() { 
                new Product(){Id = 1, Price = 35},
                new Product(){Id = 2, Price = 150},
                new Product(){Id = 3, Price = 650},
                new Product(){Id = 4, Price = 150},
                new Product(){Id = 5, Price = 15},
                new Product(){Id = 6, Price = 35},
                new Product(){Id = 7, Price = 650},
                new Product(){Id = 8, Price = 78},
                new Product(){Id = 9, Price = 35},
                new Product(){Id = 10, Price = 78},
            };
            Console.WriteLine(string.Join(",", products.Select(p=> p.Price).ToArray()));
            Console.WriteLine("Average: {0}",products.Average(p => p.Price));
            Console.WriteLine("Median: {0}",products.Median(m => m.Price));
            Console.WriteLine("Mode: {0}",products.Mode(m => m.Price));
            Console.WriteLine("UnMode: {0}",products.UnMode(m => m.Price));

        }


        public static void ShowArray(IEnumerable<string> group, string description)
        {
            Console.WriteLine("{0} {1}", description, string.Join(",", group.ToArray()));
        }

        public static Exception[] GetExceptions()
        {
            return new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidCastException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new DivideByZeroException(),
                new ApplicationException(),
                new OverflowException()
            };
        }

        public class Animal { }
        public class Dog : Animal { }
        public class Gato : Animal { }

        public static bool MoreThanFour(string text)
        {
            return text.Length > 4;
        }
    }

    class Product
    {

        public int Id { get; set; }
        public int Price { get; set; }
    }
}
