using System;
using System.Collections;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            
            //myList.Capacity = 5;
            myList.Add("Sachin");
            myList.Add(true);
            myList.Add(12.34F);
            myList.Add('A');
            myList.Add(100);
            Console.WriteLine(myList.Capacity);

            foreach(object o in myList)
            {
                Console.WriteLine(o);
                int a = (int)o;
            }
        }
    }
}
