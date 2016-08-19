using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsModifierExample
{
    //The params keyword allow you to pass zero or any number of parameters to the method.
    //You may pass comma serarated list of parameter or an array.
    class Calculator
    {
        // Return average of "some number" of doubles.
        public static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Pass in a comma-delimited list of doubles...
            double average;
            average = Calculator.CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);

            // ...or pass an array of doubles.
            double[] data = { 4.0, 3.2, 5.7 };
            average = Calculator.CalculateAverage(data);
            Console.WriteLine("Average of data is: {0}", average);
            // Average of 0 is 0!
            Console.WriteLine("Average of data is: {0}", Calculator.CalculateAverage());

            Console.ReadLine();
        }
    }
}
