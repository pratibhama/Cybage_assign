using System;
using System.Collections;


//This example demonstrates The IEnumerable and IEnumerator Interfaces
/*
 To solve the problem in Example2,
 Inherit IEnumerable interface in Cybage class and implement the single method GetEnumerator().
 The GetEnumerator() method returs object of IEnumerator interface that allows other classes to
 iterate over the internal collection of objects in Cybage class.
*/
/*
namespace Demo1
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }

    class Cybage : IEnumerable   
    {
        //create an array of Employee objects
        Employee[] empArray = new Employee[2];
        
        public Cybage()
        {
            //add employee objects to array
            empArray[0] = new Employee { EmployeeId = 1, Name = "Sachin" };
            empArray[1] = new Employee { EmployeeId = 2, Name = "Saurav" };
        }

        //returns the IEnumerator of array objects
        public IEnumerator GetEnumerator()
        {
            return empArray.GetEnumerator();
        }
    }

    

    class Example3
    {
        static void Main(string[] args)
        {          

            Cybage cyb = new Cybage();

            //iterate over an array of internal objects(employee objects) of Cybage class
            foreach (Employee emp in cyb)
            {
                Console.WriteLine("Employee Id : {0}", emp.EmployeeId);
                Console.WriteLine("Name : {0}", emp.Name);
                Console.WriteLine("================================");
            }

            Console.ReadLine();
        }
    }
}
*/