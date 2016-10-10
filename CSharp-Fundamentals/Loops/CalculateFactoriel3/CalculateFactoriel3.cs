using System;
using System.Numerics;

class CalculateFactoriel3
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        BigInteger factorielN = 1;
        BigInteger factorielK = 1;
        BigInteger factorielSub = 1;
        BigInteger sum = 0;

        for (int i = 1; i <= n; i++)
        {
            factorielN *= i;
        }

        for (int j = 1; j <= k; j++)
        {
            factorielK *= j;
        }

        for (int l = 1; l <= (n - k); l++)
        {
            factorielSub *= l;
        }

        sum = factorielN / (factorielK * factorielSub);
        Console.WriteLine(sum);
    }
}
