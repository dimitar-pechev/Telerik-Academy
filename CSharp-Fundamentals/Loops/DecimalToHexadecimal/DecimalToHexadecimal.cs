using System;

class DecimalToHex
{
    static void Main()
    {
        long dec = long.Parse(Console.ReadLine());
        string hex = "";
        string remainder = "";

        if (dec == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            while (dec > 0)
            {
                long checkRemainder = dec % 16;
                switch (checkRemainder)
                {
                    case 10:
                        remainder = "A";
                        break;
                    case 11:
                        remainder = "B";
                        break;
                    case 12:
                        remainder = "C";
                        break;
                    case 13:
                        remainder = "D";
                        break;
                    case 14:
                        remainder = "E";
                        break;
                    case 15:
                        remainder = "F";
                        break;
                    default:
                        remainder = checkRemainder.ToString();
                        break;
                }

                hex = remainder + hex;
                dec /= 16;
            }

            Console.WriteLine(hex);
        }
    }
}