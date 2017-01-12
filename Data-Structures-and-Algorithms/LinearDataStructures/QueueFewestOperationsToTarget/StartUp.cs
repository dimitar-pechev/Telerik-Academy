using System;
using System.Collections.Generic;

namespace QueueFewestOperationsToTarget
{
    public class StartUp
    {
        public static void Main()
        {
            // n - starting number
            // m - target number
            // allowed operations: n + 1, n + 2, n * 2
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var result = GetFewestOpertaionsToTarget(n, m);

            while(result.Count != 0)
            {
                Console.WriteLine(result.Dequeue());
            }
        }

        public static Queue<int> GetFewestOpertaionsToTarget(int start, int end)
        {
            var result = new Queue<int>();

            int next = start;
            result.Enqueue(start);

            while (true)
            {
                var current = next;

                var finalOperation = (current + 1 == end) || (current + 2 == end) || (current * 2 == end);

                if (finalOperation)
                {
                    result.Enqueue(end);
                    return result;
                }

                if (current * 2 * 2 <= end)
                {
                    next = current * 2;
                }
                else if ((current + 2) * 2 <= end)
                {
                    next = current + 2;
                }
                else if ((current + 1) * 2 <= end)
                {
                    next = current + 1;
                }
                else if (current * 2 + 2 <= end)
                {
                    next = current * 2;
                }
                else if (current * 2 + 1 <= end)
                {
                    next = current * 2;
                }
                else if (current + 2 + 2 <= end)
                {
                    next = current + 2;
                }
                else if (current + 2 + 1 == end)
                {
                    result.Enqueue(current + 2);
                    result.Enqueue(current + 1);

                    return result;
                }

                result.Enqueue(next);
            }
        }
    }
}
