/*
using System;
namespace jagged_array
{
    class Program
    {
        static void Main()
        {
            // Declare
            int[][] jaggedarray = new int[4][];
            // Intialization
            jaggedarray[0] = new int[2] { 7, 9 };
            jaggedarray[1] = new int[4] { 12, 42, 26, 67 };
            jaggedarray[2] = new int[6] { 7, 9, 67, 90, 5, 3 };
            jaggedarray[3] = new int[3] { 7, 9, 9000 };

            //Dispaly
            for (int i = 0; i < jaggedarray[i].Length; i ++)
            {
                System.Console.WriteLine("Element({0}) : ", i + 1);
                for (int j = 0; j < jaggedarray[i].Length; j++)
                {
                    System.Console.WriteLine(jaggedarray[i][j] + "\t");
                }
                System.Console.WriteLine();
            }
            Console.WriteLine();

         }
    }
}

*/


// Single Dimension array
/*
using System;

namespace jagged_array
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, -1, -2 };

            foreach (int i in numbers)
            {
                Console.WriteLine($"{i} ");
            }
        }
    }
}
*/

// Multi dimensiion
/*
using System;

namespace jagged_array
{
    class Program
    {
        static void Main()
        {
            int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            // Or use the short form
            // int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            foreach (int i in numbers2D)
            {
                Console.WriteLine(i);
            }
        }
    }
}
*/
/*
// Activity 4
namespace jagged_array
{
    class Program
    {
        static void Main()
        {
            // Declare and Intialize
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            // pass the array to argument
            PrintArray(weekDays);


            //ChangeArray tries to change the array by assigning something new 
            // to the array in the method
            ChangeArray(weekDays);


            //Print the array again, to veify that it has been not changed.
            Console.WriteLine("Array week days the call to change : ");
            PrintArray(weekDays);
            System.Console.WriteLine();

            //Change array elements assign new value to indivduals  array elements
            ChangeArrayElements(weekDays);

            // The changes to indivhdual elemnts to presisit after method returns.
            //Print the array to verify that it has been changed
        }

        private static void ChangeArray(string[] weekDays)
        {
            weekDays = (weekDays.Reverse().ToArray());
            Console.WriteLine("arr[0] is {0} in changearray ", weekDays[0]);


        }

        private static void PrintArray(string[] weekDays)
        {
            for(int i = 0; i < weekDays.Length; i++)
            {
                Console.Write(weekDays[i] + "{0}",i< weekDays.Length - 1 ? " " : "");
            }
        }

        private static void ChangeArrayElements(string[] weekDays)
        {
            weekDays[0] = "Sat";
            weekDays[1] = "Fri";
            weekDays[2] = "Thu";

            Console.WriteLine("arr[0] is {0} on changearray elements ", weekDays[0]);
        }
    }
}
*/









// Exercise 01

/*
using System;

namespace ArrayExample
{
    class Program
    {
        static void Main()
        {
            int[,] array = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Print2DArray(array);
        }

        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

*/

// Exercise 02
/*
using System;

namespace StringMerger
{
    class Program
    {
        static void Main()
        {
            string[] s = { "hello ", "and ", "welcome ", "to", "this", "demo! " };
            string result = Merger(s);
            Console.WriteLine(result);
        }

        static string Merger(string[] strings)
        {
            return string.Concat(strings);
        }
    }
}
*/

// Exercise 03
/*
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = "This is a simple example with words of various lengths.";
        string[] result = ExtractWords(input);

        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }

    public static string[] ExtractWords(string input)
    {
        List<string> result = new List<string>();
        string[] words = input.Split(' ');

        foreach (string word in words)
        {
            if (word.Length >= 4 && word.Length <= 5 && ContainsVowel(word))
            {
                result.Add(word);
            }
        }

        return result.ToArray();
    }

    public static bool ContainsVowel(string word)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        foreach (char letter in word)
        {
            if (Array.Exists(vowels, vowel => vowel == letter))
            {
                return true;
            }
        }
        return false;
    }
}
*/

//Exercise 04
/*
using System;

namespace CafeteriaRatings
{
    class Program
    {
        static void Main()
        {
            int[] responses = { 2, 3, 4, 4, 3, 2, 5, 3, 4, 4, 3, 2, 5, 3, 4, 4, 3, 2, 5, 3, 4, 4, 3, 2, 5, 3, 4, 4, 3, 2, 5, 3, 4, 4, 3, 2, 5, 3, 4, 4 };

            int[] frequency = new int[6]; // Using index 0 to 5 for simplicity

            foreach (var response in responses)
            {
                frequency[response]++;
            }

            for (int rating = 1; rating < frequency.Length; rating++)
            {
                Console.WriteLine($"Response {rating} given by: {frequency[rating]} people");
            }
        }
    }
}
*/


// Exercise 05

using System;

namespace NumberConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a decimal number:");
                int decimalNumber = int.Parse(Console.ReadLine());
                string binary = DecimalToBinary(decimalNumber);
                Console.WriteLine($"Binary: {binary}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }

            try
            {
                Console.WriteLine("Enter a binary number:");
                string binaryNumber = Console.ReadLine();
                int decimalResult = BinaryToDecimal(binaryNumber);
                Console.WriteLine($"Decimal: {decimalResult}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid binary number.");
            }
        }

        static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";
            string binary = "";
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary;
                decimalNumber /= 2;
            }
            return binary;
        }

        static int BinaryToDecimal(string binaryNumber)
        {
            int decimalResult = 0;
            int baseValue = 1;
            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] == '1')
                {
                    decimalResult += baseValue;
                }
                baseValue *= 2;
            }
            return decimalResult;
        }
    }
}

