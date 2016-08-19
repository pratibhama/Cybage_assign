using System;
using System.Collections.Generic;
using System.Linq;

//This example demonstrates a simple LINQ query - LINQ to Objects
/*
 The first foreach is just iterating over all the elements of array object.
 But it is neither filtering nor ordering the elements of array object.
 The second foreach is executing a IEnumerable object or result of LINQ query.
 It is showing only filtered data in sorted order.
 */

/*
namespace Demo1
{
    class Example4
    {
        static void Main(string[] args)
        {
            
            //creating data source

            string[] names = 
            { 
                "Suman", "Sachin", "Saurav", "Shankar", "Abhishek", "Rahul" 
            };

            Console.WriteLine("Elements of string array");
            //executing query directly against the array object
            foreach (string s in names)
            {
                Console.WriteLine(s);
            }

            
            //Querying Array object - A Deferred Execution
            
            IEnumerable<string> sortedNames = from n in names
                                              where n.StartsWith("S")
                                              orderby n
                                              select n;

            Console.WriteLine("Results of a LINQ query");
            //executing query against the IEnumerable object returned by LINQ qeury
            
            foreach(string s in sortedNames)
            {
                Console.WriteLine(s);
            }  
            
        }
    }
}
*/