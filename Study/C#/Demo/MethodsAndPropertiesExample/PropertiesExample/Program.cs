using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesExample
{
    class Employee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        // Properties!
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name must be less than 16 characters!");
                else
                    empName = value;
            }
        }

        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
