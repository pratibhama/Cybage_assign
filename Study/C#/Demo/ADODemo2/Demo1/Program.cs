using System;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DAL.CheckConnection();
            Console.WriteLine("Enter product id");
            int productId;
            if(int.TryParse(Console.ReadLine(), out productId))
            {
                DAL.GetProducts(productId);
            }
        }
    }
}
