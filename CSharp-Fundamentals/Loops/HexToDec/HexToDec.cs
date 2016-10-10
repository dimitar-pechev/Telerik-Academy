using System;

class HexToDecimal
{
    static void Main()
    {
        string hex = Console.ReadLine();
        long dec = 0;
        int multiplier;

        for (int i = 0; i < hex.Length; i++)
        {

            switch (hex[hex.Length - i - 1])
            {
                case 'A':
                    multiplier = 10;
                    break;
                case 'B':
                    multiplier = 11;
                    break;
                case 'C':
                    multiplier = 12;
                    break;
                case 'D':
                    multiplier = 13;
                    break;
                case 'E':
                    multiplier = 14;
                    break;
                case 'F':
                    multiplier = 15;
                    break;
                default:
                    multiplier = int.Parse(hex[hex.Length - i - 1].ToString());
                    break;
            }

            dec += multiplier * (long)Math.Pow(16, i);
        }

        Console.WriteLine(dec);
    }
}