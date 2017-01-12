using System;
using System.Collections.Generic;

namespace ListSorting
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
                list.Sort();
                Console.WriteLine("Sorted elements:");
                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
            }
            else
            {
                Console.WriteLine("No numbers passed...");
            }
        }
    }
}
