using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue();
            myQueue.Enqueue("One");
            myQueue.Enqueue("Two");
            myQueue.Enqueue("Three");

            myQueue.Dequeue();
            foreach (string s in myQueue)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
