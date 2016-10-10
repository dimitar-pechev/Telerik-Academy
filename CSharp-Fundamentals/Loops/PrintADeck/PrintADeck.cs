using System;

public class PrintADeck
{
    public static void Main()
    {
        string card = Console.ReadLine();
        string[] deck = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        int value = 0;
        switch (card)
        {
            case "2": value = 1; break;
            case "3": value = 2; break;
            case "4": value = 3; break;
            case "5": value = 4; break;
            case "6": value = 5; break;
            case "7": value = 6; break;
            case "8": value = 7; break;
            case "9": value = 8; break;
            case "10": value = 9; break;
            case "J": value = 10; break;
            case "Q": value = 11; break;
            case "K": value = 12; break;
            case "A": value = 13; break;
            default: break;
        }
        for (int i = 0; i < value; i++)
        {
            Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", deck[i]);
        }
    }
}