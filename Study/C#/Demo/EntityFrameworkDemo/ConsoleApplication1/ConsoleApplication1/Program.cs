using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//code first to new database
namespace ConsoleApplication1
{
    class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //public virtual List<Employee> Employees { get; set; }
    }

    class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        //[ForeignKey("DepartmentId")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }

    class EmpDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }

    class Program
    {
        EmpDbContext db = new EmpDbContext();

        public void AddDepartment()
        {
            Department dept = new Department();

            //dept.DepartmentID = 1;
            Console.WriteLine("Enter Department name");
            dept.Name = Console.ReadLine();
            Console.WriteLine("Enter Location");
            dept.Location = Console.ReadLine();

            db.Department.Add(dept);
            db.SaveChanges();
            Console.WriteLine("A department added successfully");
        }

        public void GetDepartments(int? id)
        {
            var departments = from dept in db.Department
                              select dept;

            if(id != null)
            {
                departments = from dept in db.Department
                              where dept.DepartmentID == id
                              select dept;
            }

            Console.WriteLine("Showing department(s)");
            Console.WriteLine("ID \t Name \t Location");
            foreach(Department dept in departments)
            {                
                Console.WriteLine("{0} \t {1} \t {2}", dept.DepartmentID, dept.Name, dept.Location);
            }
        }

        public void AddEmployee()
        {
            Employee emp = new Employee();

            Console.WriteLine("Enter Name");
            emp.Name = Console.ReadLine();

            Console.WriteLine("Enter City");
            emp.City = Console.ReadLine();

            Console.WriteLine("Enter DepartmentID");
            emp.DepartmentID = int.Parse(Console.ReadLine());

            db.Employee.Add(emp);
            db.SaveChanges();
        }

        public void GetEmployee(int? empId)
        {
            //fetching all employees
            var employees = from emp in db.Employee
                            select emp;

            //fetching single employee by id
            if(empId != null)
            {
                employees = from emp in db.Employee
                            where emp.EmployeeID == empId
                            select emp;
            }

            employees.Count();

            if(employees == null)
            {
                Console.WriteLine("No employee found");
                return;
            }

            Console.WriteLine("Showing department(s)");
            Console.WriteLine("ID \t Name \t City \t DepartmentID");
            foreach(Employee emp in employees)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", emp.EmployeeID, emp.Name, emp.City, emp.DepartmentID);
            }
        }

        public void GetEmployeeByDepartment(int? id)
        {
            var employee = from emp in db.Employee
                           where emp.DepartmentID == id
                           select new { Name = emp.Name, Department = emp.Department.Name };

            foreach(var emp in employee)
            {
                Console.WriteLine("Employee Name : {0} - Department Name {1}", emp.Name, emp.Department);
                Console.WriteLine("==============================================");
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();


            //p.AddDepartment();
            //p.GetDepartments(null);
            //p.GetEmployeeByDepartment(1);
           
            p.AddEmployee();
            p.GetEmployee(null);

            
        }
    }
}
