using System;

class NumbersFromOneToN
{
    static void Main()
    {
        var num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= num; i++)
        {
            Console.WriteLine(i);
        }
    }
}