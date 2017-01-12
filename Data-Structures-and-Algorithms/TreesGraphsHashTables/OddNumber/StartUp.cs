using System;

namespace OddNumber
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            long result = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                result ^= long.Parse(Console.ReadLine());
            }

            Console.WriteLine(result);
        }
    }
}
