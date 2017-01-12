using System;
using System.Collections.Generic;
using System.Linq;

namespace PenguinAirlines
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var flights = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                if (line == "None")
                {
                    flights[i] = new List<int>();
                }
                else
                {
                    flights[i] = line.Split(' ').Select(int.Parse).ToList();
                }
            }

            var components = new int[n];
            var isVisited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!isVisited[i])
                {
                    CheckConnection(isVisited, i, flights, i, components);
                }
            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Have a break")
                {
                    break;
                }

                var a = int.Parse(line.Split(' ').ToArray()[0]);
                var b = int.Parse(line.Split(' ').ToArray()[1]);

                if (flights[a].Contains(b))
                {
                    Console.WriteLine("There is a direct flight.");
                }
                else
                {
                    if (components[a] == components[b])
                    {
                        Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                    }
                    else
                    {
                        Console.WriteLine("No flights available.");
                    }
                }
            }
        }

        private static void CheckConnection(bool[] isVisited, int start, List<int>[] flights, int id, int[] components)
        {
            isVisited[start] = true;
            components[start] = id;

            foreach (var dest in flights[start])
            {
                if (!isVisited[dest])
                {
                    CheckConnection(isVisited, dest, flights, id, components);
                }
            }
        }
    }
}
