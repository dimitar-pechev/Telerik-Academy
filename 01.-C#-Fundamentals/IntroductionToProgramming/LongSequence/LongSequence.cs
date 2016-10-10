using System;

class LongSequence
{
    static void Main()
    {
        for (int numbers = 2; numbers < 1001; numbers++)
        {
            if (numbers % 2 == 0)
            {
                Console.WriteLine("{0},", numbers);
            }
            else
            {
                Console.WriteLine("{0},", -numbers);
            }

        }
    }
}