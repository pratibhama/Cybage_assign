using System;

namespace HelloWorldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("First Name : {0} and Last Name : {1}", args.GetValue(0), args.GetValue(1));
            //Console.WriteLine("Second Parameter : {0}", args.GetValue(1));
        }
    }
}
