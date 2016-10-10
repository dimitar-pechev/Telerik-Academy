using System;

class Batman
{
    static void Main()
    {
        var size = int.Parse(Console.ReadLine());
        var symbol = char.Parse(Console.ReadLine());
        var whiteSpace = ' ';

        var upperRows = size / 2;
        int centralRows = size / 3;
        var lowerRows = upperRows;

        for (int i = 0; i < upperRows; i++)
        {
            Console.Write(new string(whiteSpace, i));
            Console.Write(new string(symbol, size - i));

            if (i != upperRows - 1)
            {
                Console.Write(new string(whiteSpace, size));
                Console.WriteLine(new string(symbol, size - i));
            }
            else
            {
                if (size % 2 == 0)
                {
                    Console.Write(new string(whiteSpace, (size / 2) - 2));
                    Console.Write("{0}  {0}", symbol);
                    Console.Write(new string(whiteSpace, (size / 2) - 2));
                    Console.WriteLine(new string(symbol, size - i));
                }
                else
                {
                    Console.Write(new string(whiteSpace, (size / 2) - 1));
                    Console.Write("{0}{1}{0}", symbol, whiteSpace);
                    Console.Write(new string(whiteSpace, (size / 2) - 1));
                    Console.WriteLine(new string(symbol, size - i));
                }
            }
        }

        for (int i = 0; i < centralRows; i++)
        {
            Console.Write(new string(whiteSpace, size / 2));
            Console.WriteLine(new string(symbol, (size * 3) - (2 * (size / 2))));
        }

        for (int i = 1; i <= lowerRows; i++)
        {
            Console.Write(new string(whiteSpace, size + i));
            Console.WriteLine(new string(symbol, (size - (2 * i))));
        }
    }
}