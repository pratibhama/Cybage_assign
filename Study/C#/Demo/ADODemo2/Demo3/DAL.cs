using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Demo3
{
    class DAL
    {
        public DataSet ds;
        private SqlDataAdapter daCustomer;//, daOrder;
        private string conStr;
        public readonly string dataFile = @"C:\Demo\TestDB.xml";
        private readonly string schemaFile = @"C:\Demo\TestDB.xsd";

        public void CreateSchema()
        {
            //create a new dataset
            ds = new DataSet("TestDB");

            //create a new table in the dataset
            var customer = ds.Tables.Add("Customer");
            //add columns to the table
            var pkCustomerId = customer.Columns.Add("CustomerId", typeof(int));
            //set CustomerId as auto increment column
            pkCustomerId.AutoIncrement = true;
            //setting -1 will generate negative values to avoid clash with auto generated ids by the database
            pkCustomerId.AutoIncrementSeed = -1;
            pkCustomerId.AutoIncrementStep = -1;

            customer.Columns.Add("Name", typeof(string));
            customer.Columns.Add("City", typeof(string));
            customer.Columns.Add("Phone", typeof(long));
            //create primary key column
            customer.PrimaryKey = new DataColumn[] { customer.Columns["CustomerId"] };

            ds.WriteXmlSchema(schemaFile);
            Console.WriteLine("Schema created successfully");
        }

        public void InitializeDataAdapters()
        {
            conStr = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;

            daCustomer = new SqlDataAdapter("SELECT * FROM Customer", conStr);
            SqlCommandBuilder cmdBuilderCustomer = new SqlCommandBuilder(daCustomer);
        }

        public void PopulateDataSet()
        {
            if (File.Exists(schemaFile))
            {
                ds = new DataSet();
                ds.ReadXmlSchema(schemaFile);
            }
            else
            {
                CreateSchema();
            }
            if (File.Exists(dataFile))
            {
                ds.ReadXml(dataFile, XmlReadMode.IgnoreSchema);
            }
        }

        public void GetCustomer()
        {
            int rowsCount = ds.Tables["Customer"].Rows.Count;
            if (rowsCount > 0)
            {
                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    Console.WriteLine("Customer Id : {0}", row["CustomerId"]);
                    Console.WriteLine("Name : {0}", row["Name"]);
                    Console.WriteLine("City : {0}", row["City"]);
                    Console.WriteLine("Phone : {0}", row["Phone"]);
                    Console.WriteLine("===============================================");
                }
            }
            else
                Console.WriteLine("No customer data exist");
        }

        public void AddCustomer()
        {
            string name, city, choice;
            long phone;
            bool result;

            do
            {
                Console.WriteLine("Enter Customer Details");
                Console.Write("Name : ");
                name = Console.ReadLine();
                Console.Write("City : ");
                city = Console.ReadLine();
            phoneLabel:
                Console.Write("Phone : ");
                result = long.TryParse(Console.ReadLine(), out phone);
                if (!result)
                {
                    Console.WriteLine("Invalid phone number, try again");
                    goto phoneLabel;
                }

                DataRow row = ds.Tables["Customer"].NewRow();
                row["Name"] = name;
                row["City"] = city;
                row["Phone"] = phone;
                ds.Tables["Customer"].Rows.Add(row);

                Console.WriteLine("One Customer added. Do you want to add more?(yes/no)");
                choice = Console.ReadLine();
            } while (choice == "yes" || choice == "y");
            ds.WriteXml(dataFile);
        }

        public void UpdateCustomer()
        {
            string name, city;
            int customerId;
            long phone;

            //implement appropriate data validation
            Console.WriteLine("Enter Customer Id you want to update");
            customerId = int.Parse(Console.ReadLine());

            try
            {
                DataRow row = ds.Tables["Customer"].Rows.Find(customerId);
                if (row != null)
                {
                    row.BeginEdit();
                    Console.WriteLine("Customer Details : ");

                    Console.WriteLine("Name : {0}", row["Name"]);
                    Console.WriteLine("Enter a new value");
                    row["Name"] = Console.ReadLine();

                    Console.WriteLine("City : {0}", row["City"]);
                    Console.WriteLine("Enter a new value");
                    row["City"] = Console.ReadLine();

                    Console.WriteLine("Phone : {0}", row["Phone"]);
                    Console.WriteLine("Enter a new value");
                    row["Phone"] = long.Parse(Console.ReadLine());
                    row.EndEdit();

                    ds.WriteXml(dataFile);
                    Console.WriteLine("Data Updated Successfully");
                }
                else
                    Console.WriteLine("Sorry, specified customer id does not exist");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Some error occurred while execution in the database");
                Console.WriteLine(ex.Message);

            }
        }

        public void DeleteCustomer()
        {
            int customerId;
            string response;

            //implement appropriate data validation
            Console.WriteLine("Enter Customer Id you want to delete");
            customerId = int.Parse(Console.ReadLine());

            try
            {
                DataRow row = ds.Tables["Customer"].Rows.Find(customerId);

                if (row != null)
                {
                    Console.WriteLine("Customer Details : ");

                    Console.WriteLine("Customer Id : {0}", row["CustomerId"]);
                    Console.WriteLine("Name : {0}", row["Name"]);
                    Console.WriteLine("City : {0}", row["City"]);
                    Console.WriteLine("Phone : {0}", row["Phone"]);

                    Console.WriteLine("Are you sure to delete customer details?(yes/no)");
                    response = Console.ReadLine();
                    if (response.ToUpper() == "YES")
                    {
                        row.Delete();
                        ds.WriteXml(dataFile);
                        Console.WriteLine("Data Deleted Successfully");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry! The specified Customer Id does not exist");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Some error occurred while deleting data in the database");
                Console.WriteLine(ex.Message);
            }
        }

        private bool CheckConnectivity()
        {
            try
            {
                using (var cn = new SqlConnection(conStr))
                {
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void Synchronize()
        {
            if (CheckConnectivity())
            {
                CreateTablesIfNotExisting();
                SyncData();
            }
        }

        private void CreateTablesIfNotExisting()
        {
            try
            {
                using (var cn = new SqlConnection(conStr))
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();
                    cmd.CommandText =
                    "IF NOT EXISTS ( "
                    + " SELECT * FROM sys.Tables WHERE NAME='Customer') "
                    + " CREATE TABLE Customer( "
                    + " CustomerId INT IDENTITY PRIMARY KEY, "
                    + " Name varchar(50), "
                    + " City varchar(50), "
                    + " Phone BIGINT)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SyncData()
        {
            //send changes to DB
            try
            {
                daCustomer.Update(ds, "Customer");
                Console.WriteLine("Data Synchronized Successfully");
                ds.AcceptChanges();
                ds.Tables["Customer"].Clear();

                //fill fresh data
                daCustomer.Fill(ds, "Customer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
