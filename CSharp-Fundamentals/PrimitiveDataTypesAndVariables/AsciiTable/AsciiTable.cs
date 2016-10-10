using System;

class AsciiTable
{
    static void Main()
    {
        for (int i = 33; i < 127; i++)
        {
            char a = (char)i;
            Console.Write(a);
        }
    }
}