using System;

class BonusScore
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        

        if ((input < 1) || (input > 9))
        {
            Console.WriteLine(("invalid score"));
        }
        else if (input >= 1 && input <= 3)
        {
            Console.WriteLine(input * 10);
        }
        else if (input >= 4 && input <= 6)
        {
            Console.WriteLine(input * 100);
        }
        else if (input >= 7 && input <= 9)
        {
            Console.WriteLine(input * 1000);
        }              
    }
}