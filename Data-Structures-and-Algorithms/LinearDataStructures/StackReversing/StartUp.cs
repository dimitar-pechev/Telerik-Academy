using System;
using System.Collections.Generic;

namespace StackReversing
{
    public class StartUp
    {
        public static void Main()
        {
            var stack = new Stack<int>();

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

                stack.Push(targetNumber);
            }

            if (stack.Count != 0)
            {
                Console.WriteLine("Popping elements in reversed order:");
                while (stack.Count != 0)
                {
                    Console.WriteLine(stack.Pop());
                }
            }
            else
            {
                Console.WriteLine("No numbers passed...");
            }
        }
    }
}
