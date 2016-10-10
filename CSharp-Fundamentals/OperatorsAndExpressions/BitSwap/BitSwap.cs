using System;

class BitSwap
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int lenght = Math.Min(p, q) + k;

        for (; Math.Min(p, q) < lenght; p++, q++)
        {
            uint mask1 = (uint)(n & 1 << p);
            uint mask2 = (uint)(n & 1 << q);

            if (mask1 != 0)
            {
                n = n | (uint)(1 << q);
            }
            else
            {
                n = n & (uint)(~(1 << q));
            }

            if (mask2 != 0)
            {
                n = n | (uint)(1 << p);
            }
            else
            {
                n = n & (uint)(~(1 << p));
            }
        }

        Console.WriteLine(n);
    }
}