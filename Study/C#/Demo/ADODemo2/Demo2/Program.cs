using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Demo2
{
    class DAL
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["eShopConStr"].ConnectionString;
        private static SqlConnection con;

        public static void GetProducts()
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
                SqlConnection con = new SqlConnection(conStr);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                DataSet ds = new DataSet("ProductDataSet");
                if(con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection is open now.");
                }

                da.Fill(ds, "Product");

                foreach(DataRow row in ds.Tables["Product"].Rows)
                {
                    Console.WriteLine("Product Id : {0}", row["iProductId"]);
                    Console.WriteLine("Name : {0}", row["cProductName"]);
                    Console.WriteLine("Price : {0}", row["iUnitPrice"]);
                    Console.WriteLine("Quantity : {0}", row["iQuantity"]);
                    Console.WriteLine("============================");
                }

                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection is open now.");
                }
            //}           
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DAL.GetProducts();
        }
    }
}
