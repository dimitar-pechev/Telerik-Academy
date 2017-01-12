using System;
using System.Collections.Generic;

namespace MajorantSearch
{
    public class StartUp
    {
        public static void Main()
        {
            var array = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var majorantNumber = GetMajorantNumberAsString(array);

            if (string.IsNullOrEmpty(majorantNumber))
            {
                Console.WriteLine("No majorant number found in the provided array!");
            }
            else
            {
                Console.WriteLine(majorantNumber);
            }
        }

        public static string GetMajorantNumberAsString(int[] array)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (var element in array)
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

            var result = string.Empty;
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key] > array.Length / 2)
                {
                    result = key.ToString();
                    break;
                }
            }

            return result;
        }
    }
}
