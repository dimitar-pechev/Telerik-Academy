using System;
using System.Collections.Generic;
using System.Numerics;

class OddAndEvenProduct
{
    static void Main()
    {
        int numOfInput = int.Parse(Console.ReadLine());
        string numbers = Console.ReadLine();

        List<int> list = new List<int>(Array.ConvertAll(numbers.Split(' '), int.Parse));

        BigInteger sum1 = 1;
        BigInteger sum2 = 1;

        for (int i = 0; i < numOfInput; i++)
        {
            if (i % 2 == 0)
            {
                sum1 *= list[i];
            }
            else if (i % 2 != 0)
            {
                sum2 *= list[i];
            }
        }

        if (sum1 == sum2)
        {
            Console.WriteLine("yes {0}", sum1);
        }
        else
        {
            Console.WriteLine("no {0} {1}", sum1, sum2);
        }

    }
}