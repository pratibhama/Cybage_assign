using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypesExample
{
    //All numeric types including boolean are value type and cannot be assigned a null value, 
    //because it will create empty object reference.
    //Nullable types support all the valid values of underlying data type and the null value.
    //Extremely useful when working with relational databases, where a column of a table may 
    //support null value.
    //In other words, nullable types are numerical data points with no value.
    class Program
    {
        static void LocalNullableVariables()
        {
            // Define some local nullable variables.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
            // Error! Strings are reference types!
            // string? s = "oops";
        }

        class DatabaseReader
        {
            // Nullable data field.
            public int? numericValue = null;
            public bool? boolValue = true;
            // Note the nullable return type.
            public int? GetIntFromDatabase()
            { return numericValue; }
            // Note the nullable return type.
            public bool? GetBoolFromDatabase()
            { return boolValue; }
        }

        static void Main(string[] args)
        {
            // Compiler errors!
            // Value types cannot be set to null!
            
            //bool myBool = null;
            //int myInt = null;
            
            // OK! Strings are reference types.
            string myString = null;

            DatabaseReader dr = new DatabaseReader();
            // Get int from "database".
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
                Console.WriteLine("Value of 'i' is: {0}", i.Value);
            else
                Console.WriteLine("Value of 'i' is undefined.");
            // Get bool from "database".
            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
                Console.WriteLine("Value of 'b' is: {0}", b.Value);
            else
                Console.WriteLine("Value of 'b' is undefined.");


            // If the value from GetIntFromDatabase() is null,
            // assign local variable to 100.
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            // Long-hand notation not using ?? syntax.
            int? moreData = dr.GetIntFromDatabase();
            if (!moreData.HasValue)
                moreData = 100;
            Console.WriteLine("Value of moreData: {0}", moreData);

            Console.ReadLine();
        }
    }
}
