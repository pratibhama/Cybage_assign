using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    public class CustomerManager
    {
        DAL db = new DAL();

        public void GetCustomers()
        {
            var customers = db.Customers.ToList();

            if (customers.Count > 0)
            {
                foreach (Customer c in customers)
                {
                    Console.WriteLine("Customer ID : {0}", c.CustomerId);
                    Console.WriteLine("Name : {0}", c.Name);
                    Console.WriteLine("City : {0}", c.City);
                }
            }
            else
                Console.WriteLine("No customers found in the database.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager();
            cm.GetCustomers();
        }
    }
}
