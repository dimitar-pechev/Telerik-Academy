using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeSpace
{
    public class StartUp
    {
        public static int[] results;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            results = new int[n];
            var dependencies = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                dependencies[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToList();
            }

            for (int i = 0; i < n; i++)
            {
                results[i] = CalculateMinTime(i, dependencies, minutes);
            }

            Console.WriteLine(results.Max());
        }

        private static int CalculateMinTime(int task, List<int>[] dependencies, int[] minutes)
        {
            if (results[task] > 0)
            {
                return results[task];
            }

            if (dependencies[task].Count == 1 && dependencies[task][0] == -1)
            {
                return minutes[task];
            }

            if (results[task] == -1)
            {
                Console.WriteLine(-1);
                Environment.Exit(0);
            }

            results[task] = -1;

            int largestDependency = 0;
            foreach (var dep in dependencies[task])
            {
                var depTime = CalculateMinTime(dep, dependencies, minutes);

                largestDependency = Math.Max(depTime, largestDependency);
            }

            results[task] = largestDependency + minutes[task];

            return results[task];
        }
    }
}
