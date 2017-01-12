using System;
using System.Linq;
using System.Collections.Generic;

namespace FindNumber
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbersCount = input[0];
            var index = input[1];

            var strings = Console.ReadLine().Split(' ').ToArray();
            Array.Sort(strings);

            Console.WriteLine(strings[index]);
        }       
    }
}
