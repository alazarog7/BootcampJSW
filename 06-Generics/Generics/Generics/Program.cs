using System;

namespace Generics
{
    public class MyGenericArray<T>
    {
        private T[] array;

        public MyGenericArray(int size)
        {
            array = new T[size];
        }

        public void SetItem(int index, T value)
        {
            array[index] = value;
        }

        public T GetItem(int index)
        {
            return array[index];
        }
    }

    public class MyGeneric<T> where T: class
    {

    }

    public class MyGeneric2<T> where T : new()
    {

    }

    public class Animal
    {

    }

    public class Reptil: Animal{

    }
    public class MyGeneric3<T> where T : Animal
    {

    }



    public struct MyStruct
    {

    }

    public interface MyInterface
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            //MyGenericArray<int> intArray = new MyGenericArray<int>(6);
            //for( int i = 0; i < 5; i++)
            //{
            //    intArray.SetItem(i, i);
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(intArray.GetItem(i));
            //}


            int a, b;
            char c, d;
            a = 10;
            b = 20;

            c = 'I';
            d = 'V';

            Console.WriteLine("Before calling swap");
            Console.WriteLine("a = {0}, b={1}", a, b);
            Console.WriteLine("c = {0}, d={1}", c, d);

            Swap<int>(ref a, ref b);
            Swap<char>(ref c, ref d);

            Console.WriteLine("After calling swap");
            Console.WriteLine("a = {0}, b={1}", a, b);
            Console.WriteLine("c = {0}, d={1}", c, d);


            //MyGeneric<string> name = new MyGeneric<string>();
            //MyGeneric<MyStruct> myStruct= new MyGeneric<MyStruct>();
            //MyGeneric<MyStruct> myStruct= new MyGeneric<MyStruct>();
            //MyGeneric<MyGenericArray<int>> arrayInt = new MyGeneric<MyGenericArray<int>>();

            //MyGeneric2<MyStruct> valor = new MyGeneric2<MyStruct>();
            //MyGeneric2<Persona> valor2 = new MyGeneric2<Persona>();

            //MyGeneric3<Persona> valor2 = new MyGeneric3<Persona>();

            //MyGeneric3<Reptil> valor45= new MyGeneric3<Reptil>();
        }

        public class Persona
        {
            private Persona()
            {
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        



    }
}
