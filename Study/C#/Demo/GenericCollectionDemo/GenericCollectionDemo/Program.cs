using System;
using System.Collections.Generic;

namespace GenericCollectionDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //List<string> names = new List<string>();
            //names.Add("Amitabh");
            //string[] nameArray = new string[] 
            //{
            //    "Sachin", "Saurav", "Dhoni"
            //};

            //names.AddRange(nameArray);
            //names.Sort();
            //names.Reverse();
            //foreach(string s in names)
            //{
            //    Console.WriteLine(s);
            //}

            //List<Employee> empList = new List<Employee>();
            //Employee emp1 = new Employee()
            //{
            //    EmployeeId = 1,
            //    Name = "Sachin",
            //    City = "Mumbai"
            //};

            //empList.Add(emp1);
            //empList.Add(new Employee { EmployeeId = 2, Name = "Saurav", City = "Kolkata" });
            
            //foreach(Employee emp in empList)
            //{
            //    Console.WriteLine("Employee Id : {0}, Name : {1}, City : {2}", emp.EmployeeId, emp.Name, emp.City);
            //}

            //Collection Initializer syntax(that is using object initializer inside)
            List<Employee> empList = new List<Employee>()
            {
                new Employee{ EmployeeId=1, Name="Sachin", City="Mumbai"},
                new Employee{ EmployeeId=2, Name="Dhoni", City="Ranchi"}
            };

            foreach (Employee emp in empList)
            {
                Console.WriteLine("Employee Id : {0}, Name : {1}, City : {2}", emp.EmployeeId, emp.Name, emp.City);
            }

            Console.WriteLine("Enter Employee Id");
            int empid;
            if (int.TryParse(Console.ReadLine(), out empid))
            {
                Employee employee = empList.Find(x => x.EmployeeId == empid);
                if (employee != null)
                {
                    Console.WriteLine("Employee found - Name : {0}", employee.Name);
                }
                else
                    Console.WriteLine("Employee not found");
            }
            else
            {
                Console.WriteLine("Please enter numeric value");
            }
        }
    }
}
