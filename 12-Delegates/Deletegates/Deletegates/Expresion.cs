using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Deletegates
{
    public delegate T OperationDelegate<T>();

    public class Expresion
    {
        private int first;
        private int second;

        

        public Expresion(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        private int Sum()
        {
            return first + second;
        }

        private int Substract()
        {
            return first - second;
        }

        private int Multiply()
        {
            return first * second;
        }

        public int ApplyOperator(Operation arg)
        {
            try
            {
                Func<Operation, object> calculate = (Operation op) => this.GetType()
                                                                .GetMethod(op + "", BindingFlags.Instance | BindingFlags.NonPublic)
                                                                .Invoke(this, null);



                return (int)calculate(arg);

            } catch(Exception e)
            {
                return -1;
            }
            
        }

        public int ApplyOperator2(Operation arg)
        {

            List<OperationDelegate<int>> methods = new List<OperationDelegate<int>>()
            {
                this.Sum,
                this.Substract,
                this.Multiply
            };

            foreach (OperationDelegate<int> e in methods)
            {
                if (e.GetMethodInfo().Name.Equals(arg+""))
                {
                    return e();
                }
            }

            return -1;
        }
    }

    public enum Operation
    {
        Sum, Substract, Multiply, Divide
    }
}
