using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.QueryOperations
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int DepartmentID { get; set; }
    }

    class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    class QueryOperations
    {
        List<Employee> empList = new List<Employee>()
        {
            new Employee{ EmployeeId=1, Name="Priyanka", City="Mumbai", DepartmentID=1},
            new Employee{ EmployeeId=2, Name="Rahul", City="Bangalore", DepartmentID=3},
            new Employee{ EmployeeId=3, Name="Sunil", City="Mumbai", DepartmentID=1},
            new Employee{ EmployeeId=4, Name="Akash", City="Delhi", DepartmentID=2},
            new Employee{ EmployeeId=5, Name="Kirti", City="Delhi", DepartmentID=2},
            new Employee{ EmployeeId=6, Name="Sangeeta", City="Mumbai", DepartmentID=1}
        };

        List<Department> deptList = new List<Department>()
        {
            new Department{ DepartmentID=1, Name="HR", City="Mumbai"},
            new Department{ DepartmentID=2, Name="IT", City="Delhi"},
            new Department{ DepartmentID=3, Name="Sales", City="Bangalore"}
        };

        //querying data source
        public void GetEmployee()
        {
            //Query syntax
            IEnumerable<Employee> employees = from emp in empList
                                              select emp;

            //Method syntax
            var employees2 = empList.ToList();

            Console.WriteLine("Showing all employees");
            Console.WriteLine("==================================");
            foreach (Employee emp in employees2)
            {
                Console.WriteLine("Employee ID : {0}", emp.EmployeeId);
                Console.WriteLine("Name : {0}", emp.Name);
                Console.WriteLine("City : {0}", emp.City);
                Console.WriteLine("-----------------------------------");
            }
        }

        //filtering data
        public void GetEmployeeByCity()
        {
            //returns employees from Mumbai
            //Query expression syntax
            IEnumerable<Employee> employees = from emp in empList
                                              where emp.City == "Mumbai"                                             
                                              select emp;

            //returns employees from Mumbai
            //Method syntax
            var employees1 = empList.Where(emp => emp.City == "Mumbai");

            //returns employees from either Mumbai or Delhi
            IEnumerable<Employee> employees2 = from emp in empList
                                              where emp.City == "Mumbai" || emp.City == "Delhi"
                                              select emp;

            //returns employees from Mumabi and name is Sunil
            IEnumerable<Employee> employees3 = from emp in empList
                                               where emp.City == "Mumbai" && emp.Name == "Sunil"
                                               select emp;
            
            
            Console.WriteLine("Showing employees filtered by city");
            Console.WriteLine("==================================");
            foreach (Employee emp in employees3)
            {
                Console.WriteLine("Employee ID : {0}", emp.EmployeeId);
                Console.WriteLine("Name : {0}", emp.Name);
                Console.WriteLine("City : {0}", emp.City);
                Console.WriteLine("-----------------------------------");
            }
        }

        //ordering data
        public void GetEmployeeByOrder()
        {
            string order = "desc";

            //Query syntax
            var employees = from emp in empList
                            orderby emp.Name
                            select emp;

            //Method syntax
            var employees2 = empList.OrderBy(emp => emp.Name);
            var employees3 = empList.OrderByDescending(emp => emp.Name);

            if(order == "desc")
            {
                employees = from emp in empList
                                orderby emp.Name descending
                                select emp;
            }


            Console.WriteLine("Showing employees order by name");
            Console.WriteLine("==================================");
            foreach (Employee emp in employees3)
            {
                Console.WriteLine("Employee ID : {0}", emp.EmployeeId);
                Console.WriteLine("Name : {0}", emp.Name);
                Console.WriteLine("City : {0}", emp.City);
                Console.WriteLine("-----------------------------------");
            }
        }

        //grouping data, the function return list of lists. Every group can have multiple employee objects.
        public void GetEmployeeByGroup()
        {
            //grouping employees by city
            var employees = from emp in empList
                            group emp by emp.City;

            //Method syntax
            var employees2 = empList.GroupBy(emp => emp.City);

            //iterate each group
            foreach (var employeeGroup in employees2)
            {
                Console.WriteLine("Showing {0} Employee details living at : {1}", 
                    employeeGroup.Count(), employeeGroup.Key);
                Console.WriteLine("===============================");

                //iterate each employee in a group
                foreach (var emp in employeeGroup)
                {
                    Console.WriteLine("Employee ID : {0}", emp.EmployeeId);
                    Console.WriteLine("Name : {0}", emp.Name);
                    Console.WriteLine("City : {0}", emp.City);
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }

        //joining employee and department
        public void GetEmployeeWithDepartment()
        {
            //Inner Join
            var employees = from emp in empList
                            join dept in deptList on emp.DepartmentID equals dept.DepartmentID
                            select new { Employee = emp.Name, Department = dept.Name };
           

            foreach (var emp in employees)
            {
                Console.WriteLine("Employee Name : {0}", emp.Employee);             
                Console.WriteLine("Department Name : {0}", emp.Department);
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            QueryOperations operation = new QueryOperations();

            //showing all employees
            //operation.GetEmployee();

            //filtering employees by city           
            //operation.GetEmployeeByCity();


            //ordering employees by name
            //operation.GetEmployeeByOrder();           

            //showing result of group by clause
            //operation.GetEmployeeByGroup();            

            //joining data
            operation.GetEmployeeWithDepartment();

           
        }
    }
}
