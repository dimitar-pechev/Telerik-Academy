using System;

namespace CombinationsWithoutDuplicates
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter a limit number:");
            var limitValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the desired number of digits in a combination:");
            var numberOfElements = int.Parse(Console.ReadLine());

            PrintCombinations(limitValue, numberOfElements);
        }

        private static void PrintCombinations(int limitValue, int numberOfElements, string result = "")
        {
            if (numberOfElements * 2 <= result.Length)
            {
                Console.WriteLine($"({result.Trim()})");
                return;
            }

            for (int i = 1; i <= limitValue; i++)
            {
                if (result.IndexOf(i.ToString()) != -1)
                {
                    continue;
                }

                PrintCombinations(limitValue, numberOfElements, $"{result + i} ");
            }
        }
    }
}
