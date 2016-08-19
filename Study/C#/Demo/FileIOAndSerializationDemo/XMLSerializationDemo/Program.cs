using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSerializationDemo
{
    //The class being serialized must be public
    //Marking the class with "Serializable" attribute is optional in xml serialization
    //[Serializable]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }

    class MySerializer
    {

        //serializing Employee object using XML serializer
        System.Xml.Serialization.XmlSerializer serializer = 
            new System.Xml.Serialization.XmlSerializer(typeof(List<Employee>));

        public void SerializeEmployee()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee(){ EmployeeId = 1, Name = "Sushant"},
                new Employee(){ EmployeeId = 2, Name = "Sachin"}
            };

            try
            {
                //writing serialized employee object to xml file
                using (System.IO.StreamWriter writer = 
                    new System.IO.StreamWriter(@"c:\Demo\Employee.xml"))
                {
                    serializer.Serialize(writer, empList);
                    Console.WriteLine("Employee object serialized successfully");
                }
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeserializeEmployee()
        {
            List<Employee> empList2 = new List<Employee>();

            //deserializing Employee object using XML serializer
            try
            {
                using (System.IO.StreamReader reader = 
                    new System.IO.StreamReader(@"c:\Demo\Employee.xml"))
                {
                    empList2 = (List<Employee>)serializer.Deserialize(reader);
                    Console.WriteLine("Deserializing Employee object - Reading from xml file");
                    foreach (Employee e in empList2)
                    {
                        Console.WriteLine("Employee Id : {0}", e.EmployeeId);
                        Console.WriteLine("Name : {0}", e.Name);
                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            MySerializer serializeObject = new MySerializer();
            serializeObject.SerializeEmployee();
            serializeObject.DeserializeEmployee();
        }
    }
}
