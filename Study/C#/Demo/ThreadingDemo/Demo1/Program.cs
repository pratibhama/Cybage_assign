using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo1
{
    class MultiTaskHandler
    {
        public static void PrintNumber()
        {
            int i = 1;
            while(i <= 20)
            {
                Console.WriteLine("Thread 1 says : {0}", i);
                i += 2;
                //Thread.Sleep(1000);
            }
        }

        public static void PrintNumber2()
        {
            int i = 1;
            while (i <= 20)
            {
                Console.WriteLine("Thread 2 says : {0}", i);
                i += 1;
                //Thread.Sleep(1000);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread main = Thread.CurrentThread;
            main.Name = "Main Thread";

            Console.WriteLine("{0} is executing", main.Name);

            Thread t1 = new Thread(MultiTaskHandler.PrintNumber);
            t1.Priority = ThreadPriority.Lowest;
            t1.Start();

            Thread t2 = new Thread(MultiTaskHandler.PrintNumber2);
            t2.Priority = ThreadPriority.Highest;
            t2.Start();

        }
    }
}
