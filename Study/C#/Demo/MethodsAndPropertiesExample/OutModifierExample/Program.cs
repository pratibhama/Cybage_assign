using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutModifierExample
{
    class Calculator
    {
        //the output parameter must be used in both calling and called code

        // called method must assign a value before exiting the method scope otherwise you get compiler error
        public static void Add(int a, int b, out int sum)
        {
            sum = a + b;
        }

        // Returning multiple output parameters.
        public static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // No need to assign initial value to local variables
            // used as output parameters, provided the first time
            // you use them is as output arguments.

            int result;
            Calculator.Add(10, 20, out result);
            Console.WriteLine("10 + 20 = {0}", result);
            
            //using out modifier, the caller gets multiple outputs from single method invocation

            int i; string str; bool b;
            Calculator.FillTheseValues(out i, out str, out b);
            Console.WriteLine("Int is: {0}", i);
            Console.WriteLine("String is: {0}", str);
            Console.WriteLine("Boolean is: {0}", b);
            
            Console.ReadLine();
        }
    }
}
