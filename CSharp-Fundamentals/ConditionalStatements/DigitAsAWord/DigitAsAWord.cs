using System;

class DigitAsAWord
{
    static void Main()
    {
        string inputNum = Console.ReadLine();
        string numName = "";

        switch (inputNum)
        {
            case "0": numName = "zero"; break;
            case "1": numName = "one"; break;
            case "2": numName = "two"; break;
            case "3": numName = "three"; break;
            case "4": numName = "four"; break;
            case "5": numName = "five"; break;
            case "6": numName = "six"; break;
            case "7": numName = "seven"; break;
            case "8": numName = "eight"; break;
            case "9": numName = "nine"; break;
            default: numName = "not a digit"; break;
        }
        Console.WriteLine(numName);
    }
}