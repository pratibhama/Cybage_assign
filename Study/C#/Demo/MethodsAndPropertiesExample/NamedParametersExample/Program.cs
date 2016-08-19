using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParametersExample
{
    //This feature allows you to call a method by specifying parameter values in any order.
    //Instead of passing parameters by position, specify each arguments as name : value.
    //Here name is the name of the parameter and value is compatible with the type of that parameter.

    class Program
    {
        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            // Store old colors to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // Restore previous colors.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }

        //The named parameter is useful when each parameter of a method has some default value i.e. optional parameters.
        //Now you can call the method passing only one or two arguments using their names as follows:
        //DisplayFancyMessage2(message: "Hello!"); or
        //DisplayFancyMessage2(backgroundColor: ConsoleColor.Green);
        static void DisplayFancyMessage2(ConsoleColor textColor = ConsoleColor.Blue,
                                        ConsoleColor backgroundColor = ConsoleColor.White,
                                        string message = "Test Message")
        {
            // Store old colors to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // Restore previous colors.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }

        static void Main(string[] args)
        {
            /*
            DisplayFancyMessage(message: "Wow! Very Fancy indeed!",
                                textColor: ConsoleColor.DarkRed,
                                backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green,
                                message: "Testing...",
                                textColor: ConsoleColor.DarkBlue);
            */
            //Named arguments must always be specified after all positional arguments
            // This is OK, as positional args are listed before named args.
            /*DisplayFancyMessage(ConsoleColor.Blue,
                                message: "Testing...",
                                backgroundColor: ConsoleColor.White);*/
            // This is an ERROR, as positional args are listed after named args.
            /*
            DisplayFancyMessage(message: "Testing...",
                                backgroundColor: ConsoleColor.White,
                                ConsoleColor.Blue);
             */

            //extremely useful when using optional and named parameters together
            DisplayFancyMessage2(message: "Hello!");
            DisplayFancyMessage2(backgroundColor: ConsoleColor.Yellow);

            Console.ReadLine();
        }
    }
}
