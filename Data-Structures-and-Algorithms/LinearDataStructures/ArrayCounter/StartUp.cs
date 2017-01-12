using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayCounter
{
    public class StartUp
    {
        public static void Main()
        {
            var array = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var occurrences = CountElementOccurrences(array);
            Console.WriteLine($"Input array: {string.Join(", ", array)}\nOccurrences of each element:\n{occurrences}");
        }

        public static string CountElementOccurrences(int[] array)
        {
            var dictionary = new Dictionary<int, int>();

            var sortedArray = array.ToList();
            sortedArray.Sort();

            foreach (var element in sortedArray)
            {
                if (!dictionary.ContainsKey(element))
                {
                    dictionary.Add(element, 1);
                }
                else
                {
                    dictionary[element] += 1;
                }
            }

            var sb = new StringBuilder();
            foreach (var key in dictionary.Keys)
            {
                sb.AppendLine($"[{key}] => {dictionary[key]} times");
            }

            return sb.ToString();
        }
    }
}
