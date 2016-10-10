using System;

class NumberOfPages
{
    static void Main()
    {
        int digits = int.Parse(Console.ReadLine());
        int numOfPages = 0;

        for (int i = 0; i < 9; i++)
        {
            if (digits > 0)
            {
                digits -= 1;
                numOfPages++;
            }
        }

        for (int j = 0; j < 90; j++)
        {
            if (digits > 0)
            {
                digits -= 2;
                numOfPages++;
            }
        }

        for (int k = 0; k < 900; k++)
        {
            if (digits > 0)
            {
                digits -= 3;
                numOfPages++;
            }
        }

        for (int l = 0; l < 9000; l++)
        {
            if (digits > 0)
            {
                digits -= 4;
                numOfPages++;
            }
        }

        for (int m = 0; m < 90000; m++)
        {
            if (digits > 0)
            {
                digits -= 5;
                numOfPages++;
            }
        }

        for (int n = 0; n < 900000; n++)
        {
            if (digits > 0)
            {
                digits -= 6;
                numOfPages++;
            }
        }

        Console.WriteLine(numOfPages);
    }
}