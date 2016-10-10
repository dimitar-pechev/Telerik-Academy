using System;

class BinaryToDecimal
{
    static void Main()
    {
        string input = Console.ReadLine();
        long decNum = 0;

        for (int i = 0; i < input.Length; i++)
        {
          if (input[input.Length - i - 1] == '0')
          {
              continue;
          }
          decNum += (int)Math.Pow(2, i);
        }
        Console.WriteLine(decNum);
    }
}