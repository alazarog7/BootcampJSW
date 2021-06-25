using System;
using System.Drawing;

namespace ReferenceType
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student();
            //student.Name = "Alejandro";
            //ChangeReferenceType(student);

            //Console.WriteLine(student.Name);

            string name = "Bill";

            ChangeReferenceType(name);

            Console.WriteLine(name);
        }


        public static void ChangeReferenceType(string s)
        {
            s = "Pedro"; ;
        }

    }

    class Student
    {
        public string Name;
    }
}
