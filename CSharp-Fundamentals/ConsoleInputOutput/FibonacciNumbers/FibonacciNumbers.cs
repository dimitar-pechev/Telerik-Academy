using System;

class FibonacciNumbers
{
    static void Main()
    {
        var numbersToBeShown = int.Parse(Console.ReadLine());

        var fibonacciNumbers = new long[numbersToBeShown];
        long firstPrevious = -1;
        long secondPrevious = 1;
        for (int i = 0; i < numbersToBeShown; i++)
        {
            long sum = firstPrevious + secondPrevious;
            fibonacciNumbers[i] = sum;

            firstPrevious = secondPrevious;
            secondPrevious = sum;
        }

        Console.WriteLine(string.Join(", ", fibonacciNumbers));
    }
}