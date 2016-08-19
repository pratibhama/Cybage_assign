using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class DepartmentManager
    {
        EmpDBEntities db = new EmpDBEntities();

        public void GetDepartments(int? id)
        {
            var departments = from dept in db.Departments
                              select dept;

            if (id != null)
            {
                departments = from dept in db.Departments
                              where dept.DepartmentId == id
                              select dept;
            }

            Console.WriteLine("Showing department(s)");
            Console.WriteLine("ID \t Name \t Location");
            foreach (Department dept in departments)
            {
                Console.WriteLine("{0} \t {1} \t {2}", dept.DepartmentId, dept.Name, dept.Location);
            }
        }

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
    }
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentManager dm = new DepartmentManager();
            dm.AddDepartment();
            dm.GetDepartments(null);
        }
    }
}
