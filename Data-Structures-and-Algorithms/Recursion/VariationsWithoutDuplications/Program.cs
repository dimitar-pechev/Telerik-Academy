using System;
using System.Text.RegularExpressions;

namespace VariationsWithoutDuplications
{
    public class Program
    {
        public static void Main()
        {
            var elements = new string[] { "test", "rock", "fun" };
            var numberOfElements = 3;

            PrintVariationsWithoutDuplicates(elements, numberOfElements);
        }

        private static void PrintVariationsWithoutDuplicates(string[] elements, int numberOfElements, string result = "")
        {
            var pattern = "\\s";
            if (Regex.Matches(result, pattern).Count == numberOfElements && result.Length != 0)
            {
                Console.WriteLine($"({result.Trim()})");
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (result.IndexOf(elements[i]) != -1)
                {
                    continue;
                }

                PrintVariationsWithoutDuplicates(elements, numberOfElements, $"{result + elements[i]} ");
            }
        }
    }
}
