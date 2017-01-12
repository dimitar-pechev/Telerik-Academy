using System;
using System.Linq;

namespace BoxFullOfBalls
{
    public class StartUp
    {
        public static void Main()
        {
            var possibleMoves = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(c => -c).ToList();
            if (!possibleMoves.Contains(1))
            {
                possibleMoves.Add(1);
            }

            var ab = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var games = ab[1] - ab[0] + 1;
            var balls = new int[games];

            var index = 0;
            for (int i = ab[0]; i <= ab[1]; i++, index++)
            {
                balls[index] = i;
            }

            var doesWin = new bool[ab[1] + 1];
            doesWin[0] = false;
            for (int ballsCount = 1; ballsCount <= ab[1]; ballsCount++)
            {
                foreach (var move in possibleMoves)
                {
                    if (move > ballsCount)
                    {
                        continue;
                    }

                    if (!doesWin[ballsCount - move])
                    {
                        doesWin[ballsCount] = true;
                    }
                }
            }

            var total = 0;
            for (var i = ab[0]; i <= ab[1]; i++)
            {
                if (doesWin[i])
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }
    }
}
