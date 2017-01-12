using System;

namespace NestedLoopsWithRecursion
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter a limit number:");
            Loop(int.Parse(Console.ReadLine()));
        }

        public static void Loop(int max, int n = 4, string result = "")
        {

            if (n <= 0)
            {
                Console.WriteLine(result);
                return;
            }

            for (int i = 1; i <= max; i++)
            {
                Loop(max, n - 1, $"{result + i} ");
            }
        }
    }
}
