using System;
using System.Numerics;

class CalculateAgain
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long k = long.Parse(Console.ReadLine());

        BigInteger factoriel1 = 1;
        BigInteger factoriel2 = 1;
        BigInteger sum = 0;

        for (int i = 1; i <= n; i++)
        {
            factoriel1 *= i;
        }

        for (int j = 1; j <= k; j++)
        {
            factoriel2 *= j;
        }

        sum = factoriel1 / factoriel2;
        Console.WriteLine(sum);
    }
}