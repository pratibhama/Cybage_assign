using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2;

namespace ConsoleApplication2
{
    //Code first to existing database
    class Program
    {
        EmpDBConnection db = new EmpDBConnection();

        public void AddDepartment()
        {
            Department dept = new Department();

            //dept.DepartmentID = 1;
            Console.WriteLine("Enter Department name");
            dept.Name = Console.ReadLine();
            Console.WriteLine("Enter Location");
            dept.Location = Console.ReadLine();

            db.Departments.Add(dept);
            db.SaveChanges();
            Console.WriteLine("A department added successfully");
        }

        public void GetDepartments(int? id)
        {
            var departments = from dept in db.Departments
                              select dept;

            if (id != null)
            {
                departments = from dept in db.Departments
                              where dept.DepartmentID == id
                              select dept;
            }

            Console.WriteLine("Showing department(s)");
            Console.WriteLine("ID \t Name \t Location");
            foreach (Department dept in departments)
            {
                Console.WriteLine("{0} \t {1} \t {2}", dept.DepartmentID, dept.Name, dept.Location);
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            p.GetDepartments(null);

            //p.AddDepartment();
        }
    }
}
