using System;
using System.IO;

namespace ExceptionHandlingDemo
{
    class SalaryException : ApplicationException
    {
        public SalaryException(string message) : base(message)
        {

        }
    }

    class Employee
    {
        public void Method1()
        {
            Console.WriteLine("Method1 called");

            try
            {
                Method2();
                //throw new System.Exception();
                //throw new DivideByZeroException();
                //throw new System.IO.FileNotFoundException();
                //throw new CustomException("Some custom exception is thrown");
                Console.WriteLine("Returned to Method1");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("This block handles only Divide By Zero Exceptions");
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("This block handles only File Not Found Exceptions");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("An Unknown Exception Handled");
                Console.WriteLine("This block handles all the exception in case there is no specific match");
                Console.WriteLine(ex.Message);

                //Console.WriteLine(ex.Source);
                //Console.WriteLine(ex.StackTrace);
                //Console.WriteLine(ex.TargetSite);
            }
            finally
            {
                Console.WriteLine("Cleaning memory");
            }
        }

        public void Method2()
        {
            Console.WriteLine("Method2 Called");
            Method3();
            Console.WriteLine("Returned to Method2");
        }

        public void Method3()
        {
            Console.WriteLine("Method3 Called");
            //throw new Exception();
        }
    }
    class Program
    {
        //main method
        /*main method executes first */
        /// <summary>
        /// Entry point of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Method1();
            //try
            //{
            //    int a, b, c;
            //    b = 5;
            //    c = 3;//the value comes from some where else
            //    a = b + c;
            //    Console.WriteLine("Result : 5 + 2 = {0}", a);

            //    //throw new DivideByZeroException();
            //    //throw new FileNotFoundException();
            //    //throw new IndexOutOfRangeException();
            //    //throw new OutOfMemoryException();
            //    int salary = 0;//assume we are getting zero from remote method call
            //    if (salary < 1)
            //    {

            //        throw new SalaryException("Salary can't be zero");
            //    }
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("Please don't divide zero");
            //    //Console.WriteLine(ex.Message);
            //    //Console.WriteLine(ex.Source);
            //    //Console.WriteLine(ex.TargetSite);
            //    //Console.WriteLine(ex.StackTrace);
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(IndexOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (SalaryException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
