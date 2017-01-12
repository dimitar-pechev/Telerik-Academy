using System;
using System.Collections.Generic;

namespace ColoredBunnies
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfBunnies = int.Parse(Console.ReadLine());

            var bunnies = new Dictionary<int, int>();
            for (int i = 0; i < numberOfBunnies; i++)
            {
                var currentAnswer = int.Parse(Console.ReadLine());
                // Counting the bunnies answer types. The keys hold value currentAnswer + 1, as the answering
                // bunny excludes itself, but should be included in the counter.
                if (!bunnies.ContainsKey(currentAnswer + 1))
                {
                    bunnies[currentAnswer + 1] = 1;
                    continue;
                }

                bunnies[currentAnswer + 1]++;
            }

            var result = 0m;
            foreach (var key in bunnies.Keys)
            {
                result += Math.Ceiling((decimal)bunnies[key] / key) * key;
            }

            if (result == 0)
            {
                result++;
            }

            Console.WriteLine(result);
        }
    }
}
