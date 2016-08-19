using System;

namespace Demo1
{
    class MyClass
    {
        [Obsolete("This method will be deprecated in future, instead use some new method.",true)]
        public void SomeMethod()
        {
            Console.WriteLine("Some method is called");
        }

        public void SomeNewMethod()
        {
            Console.WriteLine("Some new method is called");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.SomeMethod();
        }
    }
}
