using System;
using CalculatorLibrary;

namespace CalculatorLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Sum : {0}", calc.Add(5, 10));
        }
    }
}
