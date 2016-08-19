using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating array list object
            ArrayList cityList = new ArrayList(2);
            //Console.Write("Enter City or ZipCode");
            /*
            cityList.Add("ABC");
            cityList.Add('B');
            cityList.Add(2);
            cityList.Add("E");
            cityList.Add(5.4F);
            
            //display size of the collection
            Console.WriteLine("Capacity : {0}", cityList.Capacity);
            //display the no. of elements
            Console.WriteLine("Element Count : {0}", cityList.Count);

            foreach (object o in cityList)
            {
                Console.WriteLine(o);
            }
            */
            ArrayList cityList3 = new ArrayList(3);
            cityList3.Add("GNR");
            cityList3.Add("PUN");
            cityList3.Add("HYD");
            cityList3.Add("RED");
            //cityList3.Add("HYD");
            
            Console.WriteLine("Capacity of CityList2 : {0}", cityList3.Capacity);

            cityList.AddRange(cityList3);
            cityList.Sort();
            cityList.Reverse();
            //removing values
            //cityList.Remove("B");
            //cityList.RemoveAt(2);

            foreach (string o in cityList)
            {
                Console.WriteLine(o);
            }
            
            Console.ReadLine();
        }
    }
}
