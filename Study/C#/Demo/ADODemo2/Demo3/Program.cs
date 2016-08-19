using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL db = new DAL();
            db.InitializeDataAdapters();
            db.PopulateDataSet();
            //db.AddCustomer();
            //db.GetCustomer();
            db.Synchronize();
        }
    }
}
