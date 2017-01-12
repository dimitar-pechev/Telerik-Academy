using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishNotation
{
    public class StartUp
    {
        public static void Main()
        {
            var expressions = Console.ReadLine().Split(' ').ToArray();
            var stack = new Stack<long>();

            foreach (var element in expressions)
            {
                long number;
                if (!long.TryParse(element, out number))
                {
                    var second = stack.Pop();
                    var first = stack.Pop();

                    switch (element)
                    {
                        case "+": number = first + second; break;
                        case "*": number = first * second; break;
                        case "-": number = first - second; break;
                        case "/": number = first / second; break;
                        case "&": number = first & second; break;
                        case "|": number = first | second; break;
                        case "^": number = first ^ second; break;

                        default:
                            break;
                    }
                }

                stack.Push(number);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
