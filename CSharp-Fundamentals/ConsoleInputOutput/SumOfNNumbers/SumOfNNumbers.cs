using System;

class SumOfNNumbers
{
    static void Main()
    {
        var numOfLines = int.Parse(Console.ReadLine());

        double sum = 0;
        for (int i = 0; i < numOfLines; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine(sum);
    }
}
