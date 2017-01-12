using System;
using System.Linq;

namespace Swapping
{
    public class StartUp
    {
        private static int[] numbers;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var swaps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }

            for (int i = 0; i < swaps.Length; i++)
            {
                Swap(swaps[i]);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        public static void Swap(int swapAround)
        {
            var targetIndex = Array.IndexOf(numbers, swapAround);

            var rightArrLength = numbers.Length - targetIndex + 1;
            var rightArray = numbers.Skip(targetIndex + 1).Take(rightArrLength).ToArray();

            var leftArrLength = targetIndex;
            var leftArray = numbers.Take(leftArrLength).ToArray();

            var middleElement = new int[] { swapAround };

            numbers = rightArray.Concat(middleElement).Concat(leftArray).ToArray();
        }
    }
}
