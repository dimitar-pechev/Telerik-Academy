using System;

class CheckForAPlayCard
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input == "2" || input == "3" || input == "4" || input == "5" ||
            input == "6" || input == "7" || input == "8" || input == "9" || 
            input == "10" || input == "J" || input == "Q" || input == "K" || 
            input == "A")
        {
            Console.WriteLine("yes {0}", input);
        }
        else
        {
            Console.WriteLine("no {0}", input);
        }
    }
}