using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Helpers
{
    internal static class InputHelper
    {
        public static int ReadInt()
        {
            string? input = Console.ReadLine();
            int value;

            while(!int.TryParse(input, out value))
            {
                Console.WriteLine("Please enter a valid value.");
                input = Console.ReadLine(); 
            }  

            return value;   
        }

        public static int ReadInt(int minValue, int maxValue)
        {
            var value = ReadInt();

            while (value < minValue || value > maxValue)
            {
                OutputHelper.WriteLine($"Please enter a number in the range from {minValue} to {maxValue}");
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt(string prompt, int minValue, int maxValue)
        {
            OutputHelper.WriteLine(prompt);

            return ReadInt(minValue, maxValue);
        }

        public static ConsoleKeyInfo ReadKey(string prompt)
        {
            OutputHelper.WriteLine(prompt);
            return Console.ReadKey();
        }


        public static string ReadString()
        {
            return Console.ReadLine();
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static DateTime ReadDateTime()
        {
            string input = Console.ReadLine();
            DateTime value;

            while (!DateTime.TryParse(input, out value))
            {
                Console.WriteLine("Please enter a valid value.");
                input = Console.ReadLine();
            }

            return value;
        }


        public static DateTime ReadDateTime(string prompt)
        {
            OutputHelper.WriteLine(prompt);
            return ReadDateTime();
        }
    }
}
