using System;
using System.Linq;

namespace GoldFever
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var rates = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            rates.Add(int.MinValue);
            
            long moneyPaid = 0;
            long moneyAcquired = 0;
            long goldAcquired = 0;

            for (int i = 0; i < n; i++)
            {
                var biggerExists = false;
                for (int j = i + 1; j < n + 1; j++)
                {
                    if (rates[j] >= rates[i])
                    {
                        biggerExists = true;
                        break;
                    }
                }

                if (biggerExists)
                {
                    moneyPaid += rates[i];
                    goldAcquired++;
                }
                else
                {
                    if (goldAcquired > 0)
                    {
                        moneyAcquired += rates[i] * goldAcquired - moneyPaid;
                        goldAcquired = 0;
                        moneyPaid = 0;
                    }
                }
            }

            Console.WriteLine(moneyAcquired);
        }
    }
}
