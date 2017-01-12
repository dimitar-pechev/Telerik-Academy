using System;
using System.Collections.Generic;

namespace Rings
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dependencies = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var dependency = int.Parse(Console.ReadLine());
                if (!dependencies.ContainsKey(dependency))
                {
                    dependencies.Add(dependency, 1);
                }
                else
                {
                    dependencies[dependency]++;
                }

            }

            long result = 1;
            foreach (var key in dependencies.Keys)
            {
                if (dependencies[key] == 1)
                {
                    continue;
                }

                result *= Factorial(dependencies[key]);
            }

            Console.WriteLine(result);
        }

        public static long Factorial(int limit)
        {
            long res = 1;
            for (int i = 1; i <= limit; i++)
            {
                res *= i;
            }

            return res;
        }
    }
}