using System;

class ModifyBit
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int value = int.Parse(Console.ReadLine());


        ulong mask = (ulong)1 << position;
        ulong num1 = mask | number;
        ulong num2 = ~mask & number;

        if (value == 1)
        {
            Console.WriteLine(num1);
        }
        else
        {
            Console.WriteLine(num2);
        }

    }
}