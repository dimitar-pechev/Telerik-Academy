using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var people = input[0];
            var lines = input[1];

            var pplArr = new int[people];
            for (int i = 0; i < people; i++)
            {
                pplArr[i] = i;
            }

            var peopleLeft = people;
            var companies = new List<HashSet<int>>();
            for (int i = 0; i < lines; i++)
            {
                var colleagues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var areInExistingCompany = false;
                foreach (var company in companies)
                {
                    if (company.Contains(colleagues[0]) || company.Contains(colleagues[1]))
                    {
                        company.Add(colleagues[0]);
                        company.Add(colleagues[1]);
                        areInExistingCompany = true;
                        pplArr[colleagues[0]] = -1;
                        pplArr[colleagues[1]] = -1;
                        peopleLeft--;
                        break;
                    }
                }

                if (!areInExistingCompany)
                {
                    peopleLeft -= 2;
                    pplArr[colleagues[0]] = -1;
                    pplArr[colleagues[1]] = -1;
                    companies.Add(new HashSet<int>() { colleagues[0], colleagues[1] });
                }
            }

            var pplToSelect = pplArr.Where(x => x != -1).ToArray();
            for (int i = 0; i < peopleLeft; i++)
            {
                companies.Add(new HashSet<int>() { pplToSelect[i] });
            }

            var count = 0;

            for (int i = 0; i < companies.Count; i++)
            {
                foreach (var comp in companies[i])
                {
                    var pplToCombineWith = people - companies[i].Count;
                    count += pplToCombineWith;
                }
            }

            Console.WriteLine(count / 2);
        }
    }
}
