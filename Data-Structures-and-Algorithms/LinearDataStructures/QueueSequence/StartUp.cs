using System;
using System.Collections.Generic;

namespace QueueSequence
{
    public class StartUp
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            var n = int.Parse(Console.ReadLine());

            // previous + 1
            // previous * 2 + 1
            // previous + 2

            queue.Enqueue(n);
            Console.WriteLine(n);
            for (int i = 0; i < 17; i++)
            {
                var prev = queue.Dequeue();
                Console.WriteLine(prev + 1);
                queue.Enqueue(prev + 1);
                Console.WriteLine(prev * 2 + 1);
                queue.Enqueue(prev * 2 + 1);
                Console.WriteLine(prev + 2);
                queue.Enqueue(prev + 2);
            }
        }
    }
}
