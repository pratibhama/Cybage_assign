using System;
using System.IO;

namespace DelegatesAndEventsDemo
{
    //in this example publisher and subscriber are in two different classes
    class Publisher
    {
        //declare a delegate
        public delegate void WriterDelegate(string str);

        //declare an event base on the above delegate
        public static event WriterDelegate WriterEvent;

        //declare handler method to pass to the delegate.
        //this method must match delegate return type and parameters
        //this method will simply write a message to console
        public static void WriteToConsole(string message)
        {
            message += "...Event Handled.";
            Console.WriteLine(message);
            Console.WriteLine("Writing to the console....Done");
        }

        //declare another handler method to pass to the delegate.
        //this method must match delegate return type and parameters
        //this method will simply write a message to a file
        public static void WriteToFile(string message)
        {
            message += "...Event Handled.";

            //open the file if exists or create a new one            
            FileStream file = new FileStream(@"c:\Demo\message.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);

            //write to the file
            writer.WriteLine(message);

            //closing stream writer
            writer.Close();

            //closing file stream
            file.Close();

            Console.WriteLine("Writing to the file....Done");
        }

        //this method will fire the event ConsoleWriterEvent
        public void FireEvent()
        {
            //Publisher.WriterEvent("Event Fired...");  

            if (Publisher.WriterEvent != null)
            {
                //Firing Event
                Publisher.WriterEvent("Event Fired...");                
            }
        }
    }
    public class Subscriber
    {
        static void Main(string[] args)
        {
            //create an object of Publisher class
            Publisher p = new Publisher();

            //Subscribe to the event published by the Publisher class
            //and pass the handler method WriteToConsole() to the delegate
            Publisher.WriterEvent += new Publisher.WriterDelegate(Publisher.WriteToConsole);

            //Subscribe to the event published by the Publisher class
            //and pass the handler method WriteToConsole() to the delegate
            Publisher.WriterEvent += new Publisher.WriterDelegate(Publisher.WriteToFile);

            p.FireEvent();

            Console.ReadLine();
        }
    }
}
