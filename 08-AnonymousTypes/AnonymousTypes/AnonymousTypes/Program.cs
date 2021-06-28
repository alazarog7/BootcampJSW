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
                LastName = "Scoot"
            };

            Console.WriteLine(student.FirstName);
            Console.WriteLine(student.FirstName);
            Console.WriteLine(student.GetType().Name);
        }
    }
}
