using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GenericListDemo
{
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //creating generic version of collection list
            List<int> myList = new System.Collections.Generic.List<int>();

            myList.Add(1);
            myList.Add(2);

            //using collection initializer
            List<string> myStringList = new System.Collections.Generic.List<string>() { "A", "B", "C" };

            foreach (int s in myList)
            {
                Console.WriteLine(s);
            }

            //Old way to initialize members
            //Employee emp = new Employee() {Name="A", Age=12 };
            //emp.Name = "A";
            //emp.Age = 12;

            //New way - creating collection of employees using collection initializer
            List<Employee> emp = new System.Collections.Generic.List<Employee>()
            {
                //setting properties using object unitializer
                new Employee{Name="B", Age=22},
                new Employee{Name="C", Age=32}
            };

            foreach (Employee e in emp)
            {
                Console.WriteLine("Name : {0}, Age : {1}", e.Name, e.Age);
            }

            Console.ReadLine();
        }
    }
}
