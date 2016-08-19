using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Employee
    {
        int employeeId;
        string name;

        public int GetEmployeeId()
        {
            return employeeId;
        }

        public void SetEmployeeId(int empid)
        {
            if (empid > 0)
            {
                employeeId = empid;
            }
            else
            {
                Console.WriteLine("Invalid employee id");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            emp.SetEmployeeId(0);
            Console.WriteLine(emp.GetEmployeeId());
        }
    }
}
