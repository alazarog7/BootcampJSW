using System;

namespace BootCamp
{
    class EjercicioFibonacci
    {
        static void Main(string[] args)
        {
            Fibonacci(2);
            Console.ReadKey(true);
        }
        static void Fibonacci(int n)
        {
            int n1 = 0;
            int n2 = 1;
            int sum = 0;
            Console.Write("0 ");
            for (int i = 1; i < n; i++)
            {
                n1 = n2;
                n2 = sum;
                sum = n1 + n2;
                Console.Write($"{sum} ");
            }
        }
    }
}
