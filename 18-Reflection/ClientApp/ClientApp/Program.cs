using CalculatorApp;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Type arithmeticDesc = typeof(Arithmetic);

            MethodInfo[] methods = arithmeticDesc.GetMethods();

            //MethodInfo[] methods = arithmeticDesc.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }

            ConstructorInfo reflectionConstruction = arithmeticDesc.GetConstructor(Type.EmptyTypes);
            
            object reflectionObject = reflectionConstruction.Invoke(new object[] { });


            MethodInfo magicMethod = arithmeticDesc.GetMethod("Sum");
            
            object magicValue = magicMethod.Invoke(reflectionObject, new object[] { 100,100 });

            Console.WriteLine("Arithmetic.Sum returned: {0}", magicValue);


            //Type t = typeof(FirstClass);

            //Console.WriteLine("Author information for {0}", t);

            //Attribute[] attrs = Attribute.GetCustomAttributes(t);

            //foreach (Attribute attr in attrs)
            //{
            //    if (attr is Author)
            //    {
            //        Author a = (Author)attr;
            //        Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
            //    }
            //}


            //var dyMethod = new DynamicMethod("Saludar", null, null, typeof(Program));

            //ILGenerator gen = dyMethod.GetILGenerator();

        }


        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
        public class Author : Attribute
        {
            string name;
            public double version;

            public Author(string name)
            {
                this.name = name;

                // Default value.  
                version = 1.0;
            }

            public string GetName()
            {
                return name;
            }
        }

        [Author("P. Ackerman",version =1.2)]
        public class FirstClass
        {
            public Author author { get; set; }
        }


    }
}
