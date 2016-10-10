using System;

class Busses
{
    static void Main()
    {
        var numOfBusses = int.Parse(Console.ReadLine());
        var groupLeader = int.Parse(Console.ReadLine());
        var groups = 1;

        for (int i = 0; i < numOfBusses - 1; i++)
        {
            var current = int.Parse(Console.ReadLine());            
            if (current <= groupLeader)
            {
                groupLeader = current;
                groups++;
            }
        }

        Console.WriteLine(groups);
    }
}