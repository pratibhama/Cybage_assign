using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameterExample
{
    //Optional Parameters allow you to call method without passing arguments when not required.
    //If required calling code may pass arguments to the method, in this case default value is ignored.
    //This technique simplifies while interacting with COM objects, such as Microsoft Office.

    //To avoid ambiguity, optional parameters must always be packed onto the end of a method 
    //signature. It is a compiler error to have optional parameters listed before nonoptional parameters.
    class Program
    {
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        // Error! The default value for an optional arg must be known at compile time!
        //This will not compile, as the value of the Now property of the DateTime class 
        //is resolved at runtime, not compile time.
        /*
        static void EnterLogData(string message, string owner = "Programmer", DateTime timeStamp = DateTime.Now)
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
            Console.WriteLine("Time of Error: {0}", timeStamp);
        }
        */

        static void Main(string[] args)
        {
            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.ReadLine();
        }
    }
}
