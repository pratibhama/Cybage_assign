using System.Data.Entity;

namespace CodeFirstDemo
{
    class DAL : DbContext
    {
        public DAL()
            : base("TestDbContext")   //database
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
