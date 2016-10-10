using System;

class NumberComparer
{
    static void Main()
    {
        var firstNum = double.Parse(Console.ReadLine());
        var secondNum = double.Parse(Console.ReadLine());

        var greaterNum = Math.Max(firstNum, secondNum);

        Console.WriteLine(greaterNum);
    }
}