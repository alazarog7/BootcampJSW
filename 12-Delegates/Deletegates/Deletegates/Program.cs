using System;
using System.Threading;

namespace Deletegates
{
    public delegate int MyDelegate(string input);
    public delegate void DisplayMessage(string input);
    public delegate int MyDelegateWithReturn(string input);
    public delegate T add<T>(T arg, T arg2);

    class Program
    {
        static void Main(string[] args)
        {
            Program program = new();

            //Console.WriteLine(program.MethodIWantToCall("text"));

            //MyDelegate myDelegate = new MyDelegate(program.MethodIWantToCall); // reference to method
            //MyDelegate myDelegate = (string n) => n.Length;

            //MyDelegate myDelegate = program.MethodIWantToCall;

            //Console.WriteLine(myDelegate("prueba"));
            //Console.WriteLine(myDelegate.Invoke("prueba"));

            //DisplayMessage displayMessage = (string input) => Console.WriteLine(input);
            //MethodExecuteDelegate(displayMessage);
            //DisplayMessage delegate1 = ClassA.WriteInformation;
            //DisplayMessage delegate2 = ClassB.WriteInformation;

            //DisplayMessage delegateOperations = delegate1 + delegate2;

            //delegateOperations("hI :)");

            //DisplayMessage delegate3 = (string msg) => Console.WriteLine(msg);

            //delegateOperations += delegate3;
            //delegateOperations("HI :(");

            //delegateOperations = delegateOperations - delegate2;
            //delegateOperations("test3");

            //delegateOperations += delegate1;
            //delegateOperations("test4");


            //MyDelegateWithReturn delegateWithReturn1 = ClassA.GetSize;
            //MyDelegateWithReturn delegateWithReturn2 = ClassB.GetSize;

            //MyDelegateWithReturn delegateResult = delegateWithReturn1 + delegateWithReturn2;

            //Console.WriteLine(delegateResult("hola"));  

            //add<int> sum = Sum;
            //Console.WriteLine(sum(12, 2));

            //add<string> sumString = Concat;
            //Console.WriteLine(sumString("alejandro", " lazaro"));

            //Func<int, double, string> f = Sum;

            //Console.WriteLine(f(3, 3.1));


            //Action<string> writeLine = Console.WriteLine;

            //writeLine("String parameter to write");


            //Predicate<string> isUpper = IsUpperCase;

            //Console.WriteLine(isUpper("ALe"));

            Expresion expresion = new(20, 10);

            var result = expresion.ApplyOperator(Operation.Sum);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine(expresion.ApplyOperator2(Operation.Sum));
            Console.WriteLine(expresion.ApplyOperator2(Operation.Substract));
            Console.WriteLine(expresion.ApplyOperator2(Operation.Divide));

        }

        public static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        public static string Sum(int x, double y)
        {
            return " " + (x + (int)y);
        }

        public static int Sum(int x, int y)
        {
            return x + y; 
        }

        public static string Concat(string x, string y) 
        {
            return x+y;
        }

        //deleate refers to memory addres of a method
        public int MethodIWantToCall(string input)
        {
            return input.Length;
        }

        public static void MethodExecuteDelegate( DisplayMessage func)
        {
            func("alejandro");
        }
    }

    public class ClassA
    {
        public static void WriteInformation(string input)
        {
            Console.WriteLine($"Called ClassA parameter {input}");
        }
        public static int GetSize(string input)
        {
            return input.Length;
        }
    }

    public class ClassB
    {
        public static void WriteInformation(string input)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Called ClassB parameter {input}");
        }
        public static int GetSize(string input)
        {
            return input.Length;
        }
    }
}
