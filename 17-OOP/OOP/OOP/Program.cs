using System;
using System.Reflection.Emit;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");

            //var dyMeth = new DynamicMethod("Saludo", null, null, typeof(Program));

            //ILGenerator gen = dyMeth.GetILGenerator();

            //gen.EmitWriteLine("Hello World");
            //gen.Emit(OpCodes.Ret);
            //dyMeth.Invoke(null, null);




        }
    }


    public interface Switcheable
    {
        public void TurnOn();
        public void TurnOff();
    }

    public class Button
    {
        public Switcheable MyLamp { get; set; }
        public void OnButtonListener()
        {

        }
    }

    public class Lamp: Switcheable
    {
        public void TurnOn() { }
        public void TurnOff() { }

    }


    public class A
    {
        public string prop { get; set; }
    }

    public partial class Class1
    {
        protected private int value1;
        public void method1() { }
    }


    public partial class Class1
    {
        public void method2()
        {

        }
    }

    public class Class2 : Class1
    {
        public Class2()
        {
            base.value1 = 5;
        }
    }
}
