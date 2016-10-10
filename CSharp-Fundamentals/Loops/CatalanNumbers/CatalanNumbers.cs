using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger n2f = 1;
        BigInteger n1f = 1;
        BigInteger nf = 1;
        int d = 2 * n;

        for (int i = 1; i <= d; i++)
        {
            n2f *= i;
        }

        for (int i = 1; i <= n + 1; i++)
        {
            n1f *= i;
        }

        for (int i = 1; i <= n; i++)
        {
            nf *= i;
        }

        BigInteger result = n2f / (n1f * nf);

        Console.WriteLine(result);
    }
}