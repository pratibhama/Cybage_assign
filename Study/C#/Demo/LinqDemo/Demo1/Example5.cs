using System;
using System.Collections.Generic;
using System.Linq;

//This example demonstrates how to force immediate execution of the query
/*
 The first query forcing immediate execution using ToList() and cache result in a single collection object sortedNames2
  The second query forcing immediate execution using ToArray() and cache result in a single collection object sortedNames3
*/

/*
namespace Demo1
{
    class Example5
    {
        static void Main(string[] args)
        {
            
            //creating data source
            //string[] names = { "Suman", "Sachin", "Saurav", "Shankar", "Abhishek", "Rahul" };          

            
            //this is an example forcing immediate execution and cache result in a single collection object
            //writing query - An immediate Execution using ToList()

            //IEnumerable<string> sortedNames2 = from n in names
            //                                   where n.StartsWith("S")
            //                                   orderby n
            //                                   select n;

            //foreach (string s in sortedNames2)
            //{
            //    Console.WriteLine(s);
            //}

            //int namesCount = sortedNames2.Count();

            //Console.WriteLine("Names count : {0}", namesCount);

            //List<string> sortedNames3 = (from n in names
            //                             where n.StartsWith("S")
            //                             orderby n
            //                             select n).ToList();

            //Console.WriteLine("Retriving names using ToList()");

            //foreach (string s in sortedNames3)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("Retriving names using ToArray()");

            ////writing query - An immediate Execution using ToArray()
            
            //var sortedNames4 = (from n in names
            //                             where n.StartsWith("S")
            //                             orderby n
            //                             select n).ToArray();
             
            //foreach(string s in sortedNames4)
            //{
            //    Console.WriteLine(s);
            //}
        }
    }
}
*/