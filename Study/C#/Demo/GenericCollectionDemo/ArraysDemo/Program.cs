using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array1 = new int[5];
            //array1[0] = 5;
            //array1[1] = 10;

            //Console.WriteLine("First Element : {0}", array1[0]);

            string[] names = new string[] { "Sachin", "Virat", "Dhoni" };
            Console.WriteLine(names.Length);

            //for(int i=0; i< names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            foreach(string s in names)
            {
                Console.WriteLine(s);
            }

            //string[,] twodarr = new string[3, 2] {{"Pune", "Mumbai"}, {"Bangalore", "Mysore"}};


        }
    }
}

