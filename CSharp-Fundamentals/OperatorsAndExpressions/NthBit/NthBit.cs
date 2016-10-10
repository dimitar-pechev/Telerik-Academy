using System;

class NthBit
{
    static void Main()
    {
        long p = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        long mask = 1 << n;
        long sum = p & mask;
        long bit = sum >> n;

        Console.WriteLine(bit);
    }
}