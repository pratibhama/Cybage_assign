using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Demo1
{
    class DAL
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["eShopConStr"].ConnectionString;
        private static SqlConnection con;

        public static bool CheckConnection()
        {
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection is open now");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        public static void GetProducts(int productId)
        {
            if (CheckConnection())
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "SELECT * FROM Product";
                cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
                if(productId > 0)
                {
                    cmd.CommandText = "uspGetProductById";
                }
                else
                {
                    cmd.CommandText = "uspGetAllProducts";
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Product Id : {0}", reader["iProductId"]);
                    Console.WriteLine("Name : {0}", reader["cProductName"]);
                    Console.WriteLine("Unit Price : {0}", reader["iUnitPrice"]);
                    //Console.WriteLine("Quantity Available : {0}", reader["iQuantity"]);
                    Console.WriteLine("================================================");
                }

                con.Close();
            }
        }
    }
}
