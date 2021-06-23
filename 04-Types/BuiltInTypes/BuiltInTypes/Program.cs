using System;
using System.Collections.Generic;
using System.Drawing;

namespace BuiltInTypes
{
    //class Point
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }

    //    public Point(int x, int y)
    //    {
    //        X = x;
    //        Y = y;
    //    }


    //}

    public class DetailedInteger
    {
        public  int Number { get; set; }
        public List<string> letters { get; set; } = new List<string>();

        public DetailedInteger(int number)
        {
            Number = number;
        }

        public void AddDetail(string letter)
        {
            letters.Add(letter);
        }

        public override string ToString()
        {
            var toString = $"{Number} [";

            //foreach(string e in letters)
            //{
            //    toString += e + ",";
            //}
            toString += string.Join(",",letters) +"]";

            return toString;
        }
    }

    struct DetailedInteger2
    {
        public int Number;
        public List<string> letters;

        public DetailedInteger2(int number)
        {
            Number = number;
            letters = new List<string>();
        }

        public void AddDetail(string letter)
        {
            letters.Add(letter);
        }

        public override string ToString()
        {
            var toString = $"{Number} [";

            //foreach(string e in letters)
            //{
            //    toString += e + ",";
            //}
            toString += string.Join(",", letters) + "]";

            return toString;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int i = 100;
            //int j = 100;

            //i = j;
            //j = 400;

            //Console.WriteLine(i);
            //ChangeValue(i);
            //Console.WriteLine(i);

            //var p1 = new Point(1, 2);
            //var p2 = p1;
            //p2.Y = 200;
            //Console.WriteLine($"{nameof(p1)} after {nameof(p2)} is modified: {p1}");
            //Console.WriteLine($"{nameof(p2)} : {p2}");

            //MutateAndDisplay(p2);

            //Console.WriteLine($"{nameof(p2)} after passing to a method: {p2}");

            var n1 = new DetailedInteger2(0);
            n1.AddDetail("A");

            Console.WriteLine(n1);

            var n2 = n1;
            n2.Number = 7;
            n2.AddDetail("B");

            Console.WriteLine(n1);
            Console.WriteLine(n2);



        }

        private static void MutateAndDisplay(Point p)
        {
            p.X = 100;
            Console.WriteLine($"Point mutated in a method: {p}");
        }


        static void ChangeValue(int x)
        {
            x = 200;
            Console.WriteLine(x);
        }

        static void ChangeValue2(object x)
        {
            x = 200;
            Console.WriteLine(x);
        }
    }
    
}
