using System;

class ThirdBit
{
    static void Main()
    {
        uint num1 = uint.Parse(Console.ReadLine());
        uint mask = 1 << 3;
        uint masked = num1 & mask;
        uint bit = masked >> 3;


        Console.WriteLine(bit);
    }
}