using System;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new
            {
                Id = 1,
                FirstName = "Jame",
                LastName = "Scoot",
                Addres = new { Id = 1, City = "London", Country = "UK"}
            };
            Console.WriteLine(student.FirstName);
            Console.WriteLine(student.FirstName);
            Console.WriteLine(student.GetType().Name);
        }
    }
}
