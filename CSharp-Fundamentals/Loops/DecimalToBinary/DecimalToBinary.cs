using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        int inputDec = int.Parse(Console.ReadLine());

        List<int> arr = new List<int>() { };

        do
        {
            arr.Add(inputDec % 2);
            inputDec /= 2;
        }
        while (inputDec != 0);

        arr.Reverse();

        foreach (int item in arr)
        {
            Console.Write(item);
        }
        Console.WriteLine();

    }
}