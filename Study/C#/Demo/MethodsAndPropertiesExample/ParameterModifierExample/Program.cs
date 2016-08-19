using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallByValueExample
{
    class Calculator
    {
        //as all numeric types are value type, copy of the original data passed to this method
        public int Add(int a, int b)
        {
            int sum = a + b;

            //the caller will not see these changes as you are modifying a copy of original data
            a = 100;
            b = 200;

            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            // Pass two variables in by value.
            int x = 10, y = 20;
            Console.WriteLine("Before call: X: {0}, Y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", calc.Add(x, y));
            Console.WriteLine("After call: X: {0}, Y: {1}", x, y);
            Console.ReadLine();
        }
    }
}
