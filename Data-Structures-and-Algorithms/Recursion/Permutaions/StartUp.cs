using System;

namespace Permutaions
{
    class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter a limit number:");
            var limitValue = int.Parse(Console.ReadLine());
            PrintCombinations(limitValue);
        }

        private static void PrintCombinations(int limitValue, string result = "")
        {
            if (limitValue * 2 <= result.Length)
            {
                Console.WriteLine($"{{{result.Trim()}}}");
                return;
            }

            for (int i = 1; i <= limitValue; i++)
            {
                if (result.IndexOf(i.ToString()) != -1)
                {
                    continue;
                }

                PrintCombinations(limitValue, $"{result + i} ");
            }
        }
    }
}
