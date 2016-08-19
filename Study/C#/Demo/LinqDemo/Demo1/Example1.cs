using System;
using System.Collections;


//This example demonstrates The IEnumerable and IEnumerator Interfaces
/*
create an array of integers and iterate over the items using foreach.
This shows no error since System.Array and many other collection classes already implements 
IEnumerable and IEnumerator interfaces
*/

/*
namespace Demo1
{
    class Example1
    {
        static void Main(string[] args)
        {            
            //create an integer array
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };

            //iterate over an array of integers
           
            foreach(int i in intArray)
            {
                Console.Write("{0}\t", i);
            }   

            Console.ReadLine();
        }
    }
}
*/