using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class Arithmetic
    {
        public int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public int MultipleSum(List<int> numbers)
        {
            int sum = 0;

            numbers.ForEach(e =>
            {
                sum += e;
            });

            return sum;
        }

        public int Substract(int number1, int number2)
        {
            return number1 - number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public int MultipleMultiplication(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new Exception("At Least 1 number");
            }

            int multiplication = 1;

            numbers.ForEach(e =>
            {
                multiplication *= e;
            });

            return multiplication;
        }

        public int Divide(int number1, int number2)
        {

            if (number2 == 0)
            {
                throw new Exception("Divisor must be different than zero");
                //return -1;
            }
            return number1 / number2;
        }

    }
}
