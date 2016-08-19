using System;

namespace DelegateDemo
{
    //This delegate can point to any methodtaking two integers and returns nothing.
    public delegate void MyDelegate(int x, int y);

    //This class contains methods that MyDelegate will point to.
    public class MyClass
    {
        public static void Add(int x, int y)
        {
            Console.WriteLine("{0} + {1} = {2}\n", x, y, x + y);
        }

        public static void Multiply(int x, int y)
        {
            Console.WriteLine("{0} * {1} = {2}\n", x, y, x * y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Implementing Sigle Cast Delegate
            /*
            //Create an Instance of MyDelegate, that points to MyClass.Add().
            MyDelegate del1 = new MyDelegate(MyClass.Add);

            //Invoke Add() method using the delegate.
            del1(5, 5);
            

            //Create an Instance of MyDelegate, that points to MyClass.Multiply().
            MyDelegate del2 = new MyDelegate(MyClass.Multiply);

            //Invoke Multiply() method using the delegate.
            del2.Invoke(5, 5);
            */

            //Implementing Multi Cast Delegate
            
            //adding reference to add method
            MyDelegate del3 = MyClass.Add;

            //adding reference to multiply method
            del3 += MyClass.Multiply;

            //invoke all methods one after another
            del3(2, 3);
            
            //removing reference to multiply method
            del3 -= MyClass.Multiply;

            //calling delegate after removing reference, only add method will be called
            del3.Invoke(2, 3);
            
            Console.ReadLine();
        }
    }
}
