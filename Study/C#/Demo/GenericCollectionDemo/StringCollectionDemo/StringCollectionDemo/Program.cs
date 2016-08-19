using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace StringCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCollection cityList = new StringCollection();
            cityList.Add("A");
            cityList.Add("2");

            foreach (string s in cityList)
            {
                Console.WriteLine(s);
            }

            StringDictionary sdList = new StringDictionary();
            sdList.Add("12", "A");
            sdList.Add("B", "15");


            foreach (System.Collections.DictionaryEntry s in sdList)
            {
                Console.Write(s.Key);
                Console.Write("\t" + s.Value);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
