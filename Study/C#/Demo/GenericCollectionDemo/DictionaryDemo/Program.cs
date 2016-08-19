using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            Dictionary<int, string> MyDictionary = new Dictionary<int, string>();
            MyDictionary.Add(1, "Sachin");
            MyDictionary.Add(2, "Virat");

            foreach (KeyValuePair<int, string> kv in MyDictionary)
            {
                Console.WriteLine("Key : {0} - Value : {1}", kv.Key, kv.Value);
            }
        }
    }
}
