using System;

namespace EventDemo
{
    class Program
    {
        public delegate void alarm();
        public event alarm ring;

        //declaring handler methods
        public static void show1() 
        {
            Console.WriteLine("Show1 Called");
        }
        public static void show2()
        {
            Console.WriteLine("Show2 Called");
        }
        public static void show3()
        {
            Console.WriteLine("Show3 Called");
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            //subscribing event
            p.ring += new alarm(show1);
            p.ring += new alarm(show2);
            p.ring += new alarm(show3);

            //invoking event or firing event
            p.ring();

            Console.ReadLine();
        }
    }
}
