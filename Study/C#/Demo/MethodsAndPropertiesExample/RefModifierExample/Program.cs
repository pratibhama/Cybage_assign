using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefModifierExample
{
    // Reference parameters must be used in both called and calling code.
    // the difference between out and ref is:
    // the output parameters do not need to be initialized before they are passed to the method.
    // but the reference parameters must be initialized before they are passed to the method.

    //Reference parameters are useful when you want to allow a method to operate on data that is
    //declared in caller scope for swapping or sorting.

    class Calculator
    {
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "One";
            string str2 = "Two";
            Console.WriteLine("Before: {0}, {1} ", str1, str2);
            Calculator.SwapStrings(ref str1, ref str2);
            Console.WriteLine("After: {0}, {1} ", str1, str2);
            Console.ReadLine();
        }
    }
}
