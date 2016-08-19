using System;
using System.Collections;


//This example demonstrates The IEnumerable and IEnumerator Interfaces
/*
create classes Employee and Cybage
Declare an array of Employee type inside Cybage
initialize the array with Employee objects in the constructor of Cybage class
In Main() method create an object of Cybage and iterate over the Employee objects using foreach
The foreach loop shows error saying "Cybage doesn't have definition of GetEnumerator() method".
 */
/*
namespace Demo1
{

    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }

    class Cybage
    {
        //create an array of Employee objects
        Employee[] empArray = new Employee[2];
        
        public Cybage()
        {
            //add employee objects to array
            empArray[0] = new Employee { EmployeeId = 1, Name = "Sachin" };
            empArray[1] = new Employee { EmployeeId = 2, Name = "Saurav" };
        }       
    }

    

    class Example2
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