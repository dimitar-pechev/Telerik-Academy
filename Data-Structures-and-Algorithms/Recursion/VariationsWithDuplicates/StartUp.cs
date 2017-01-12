using System;
using System.Text.RegularExpressions;

namespace VariationsWithDuplicates
{
    public class StartUp
    {
        public static void Main()
        {
            var elements = new string[] { "hi", "a", "b" };
            var numberOfElements = 2;

            PrintVariationsWithDuplicates(elements, numberOfElements);
        }

        private static void PrintVariationsWithDuplicates(string[] elements, int numberOfElements, string result = "")
        {
            var pattern = "\\s";
            if (Regex.Matches(result, pattern).Count == numberOfElements && result.Length != 0)
            {
                Console.WriteLine($"({result.Trim()})");
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                PrintVariationsWithDuplicates(elements, numberOfElements, $"{result + elements[i]} ");
            }
        }
    }
}
