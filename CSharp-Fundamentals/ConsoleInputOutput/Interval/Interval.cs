using System;

class Interval
{
    static void Main()
    {
        var firstNum = int.Parse(Console.ReadLine());
        var secondNum = int.Parse(Console.ReadLine());

        var counter = 0;
        for (int i = firstNum + 1; i < secondNum; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}