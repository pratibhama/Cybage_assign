using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
     //This attribute can be applied only to class or struct
    //and can be applied multiple times to a single class or struct
    [System.AttributeUsage(System.AttributeTargets.Class |
                         System.AttributeTargets.Struct,
                         AllowMultiple = true)]//multiuse attribute
    //Author is a custom attribute class used to tag name
    //of the programmer who wrote the type
    public class Author : System.Attribute
    {
        private string name;
        public double version;
        //Any constructor parameter is positional parameter
        public Author(string name)
        {
            //name is a positional parameter
            this.name = name;
            //version is a named parameter
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }

    //Applying custom attribute Author
    //Employee class is authored by a single programmer name
    [Author("Sushant", version = 1.3)]
    class Employee
    {
        //write code for Employee class here
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Retrieving information from custom attributes
            Console.WriteLine("Authors Information of Employee type");
            Attribute[] att = Attribute.GetCustomAttributes(typeof(Employee));
            //Display information about custom attributes
            foreach (Attribute a in att)
            {
                Author auth = (Author)a;
                Console.WriteLine("Author Name : {0} , Version : {1}", auth.GetName(), auth.version);
            }
        }
    }
}
