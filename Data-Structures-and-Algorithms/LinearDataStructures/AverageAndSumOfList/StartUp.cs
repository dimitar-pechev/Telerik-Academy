using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageAndSumOfList
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new List<int>();

            Console.WriteLine("Type any integer! Pass an empty line to break.");
            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int targetNumber;
                var isNumber = int.TryParse(input, out targetNumber);

                if (!isNumber)
                {
                    Console.WriteLine("Invalid input! Integer expected!");
                }

                list.Add(targetNumber);
            }

            if (list.Count != 0)
            {
                Console.WriteLine($"Average value: {list.Average()}");
                Console.WriteLine($"Sum: {list.Sum()}");
            }
            else
            {
                Console.WriteLine("No numbers passed...");
            }
        }
    }
}
