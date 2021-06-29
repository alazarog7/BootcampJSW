using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var student = new
            //{
            //    Id = 1,
            //    FirstName = "Jame",
            //    LastName = "Scoot",
            //    Addres = new { Id = 1, City = "London", Country = "UK"}
            //};
            //Console.WriteLine(student.FirstName);
            //Console.WriteLine(student.FirstName);
            ////Console.WriteLine(student.GetType().Name);

            //var studes = new[]
            //{
            //    new { Id= 1, Location= "London", Country= "BO"},
            //    new { Id= 1, Location= "London", Country= "BO"},
            //    new { Id= 1, Location= "London", Country= "BO"}
            //};


            //IList<Student> studentList = new List<Student>()
            //{
            //    new Student{ StudentID = 1, StudentName = "Alejandro", Age = 1},
            //    new Student{ StudentID = 2, StudentName = "Alejandro", Age = 1},
            //    new Student{ StudentID = 3, StudentName = "Pepe", Age = 1}
            //};

            //var result = from s in studentList
            //             select new { Id = s.StudentID, Name = s.StudentName};

            //foreach( var e in result)
            //{
            //    Console.WriteLine(e);

            //    //Console.WriteLine(e.GetType().ToString());
            //}


            Anonymous anonymous = new Anonymous();

            dynamic anonymousDynamicData = anonymous.getData();
            Console.WriteLine(string.Format("{0} {1}", anonymousDynamicData.Name, anonymousDynamicData.EmailID));


            object anonymousData = anonymous.getData();
            PropertyInfo[] values = anonymousData.GetType().GetProperties();
            Console.WriteLine(string.Format("{0} {1}" , values[0].GetValue(anonymousData, null), values[1].GetValue(anonymousData, null)));
        }
    }

    internal class Anonymous
    {
        public object getData()
        {
            return new { Name = "Pepe", EmailID = "pepe@gmail.com" };
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
