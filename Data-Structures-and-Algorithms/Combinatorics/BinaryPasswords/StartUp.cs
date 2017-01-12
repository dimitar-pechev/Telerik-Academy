using System;

namespace BinaryPasswords
{
    public class StartUp
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            var counter = 0;

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                long result = 1;
                for (int i = 0; i < counter; i++)
                {
                    result *= 2;
                }

                Console.WriteLine(result);
            }
        }
    }
}
