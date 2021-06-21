using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = -100;
            int num2 = -128;
            short num3 = 3540;
            int num4 = 64876;
            long num5 = 2147483648;
            long num6 = -1141583228;
            long num7 = -1223372036854770;
            int num8 = 808;
            int num9 = 2_000_000;
            int num10 = 0b_0001_1110_1000_0100_1000_0000;
            int num11 = 0x_001E_8480;



            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);
            Console.WriteLine(num8);
            Console.WriteLine(num9);
            Console.WriteLine(num10);
            Console.WriteLine(num11);


            //Segunda parte
            decimal num12 = 3.141592653589793238M;
            decimal num13 = 1.60217657M;
            decimal num14 = 7.8184261974584555216535342341M;

            Console.WriteLine(num12.ToString().Replace(",", "."));
            Console.WriteLine(num13.ToString().Replace(",","."));
            Console.WriteLine(num14.ToString().Replace(",", "."));


        }
    }
}
