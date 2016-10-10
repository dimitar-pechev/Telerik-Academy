using System;

class BobiAvokadoto
{
    static void Main()
    {
        uint head = uint.Parse(Console.ReadLine());
        uint numOfCombs = uint.Parse(Console.ReadLine());

        uint matches = 0;
        uint perfectMatch = 0;
        uint bestComb = 0;

        for (int i = 0; i < numOfCombs; i++)
        {
            uint comb = uint.Parse(Console.ReadLine());
            matches = 0;

            for (int j = 0; j < 32; j++)
            {
                int combBit = ((((int)1 << (int)j) & (int)comb) >> j);
                int headBit = ((((int)1 << (int)j) & (int)head) >> j);

                if (combBit != headBit)
                {
                    matches++;
                }
                else if (combBit == 1 && headBit == 1)
                {
                    matches = 0;
                    break;
                }
            }

            if (matches > perfectMatch)
            {
                perfectMatch = matches;
                bestComb = comb;
            }
        }

        Console.WriteLine(bestComb);
    }
}