using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();
            myStack.Push("One");
            myStack.Push("Two");
            myStack.Push("Three");

            myStack.Pop();
            foreach (string s in myStack)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
