using System;
using System.Collections.Generic;
using System.Linq;

namespace ListMethods
{
    public class StartUp
    {
        public static void Main()
        {
            // Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
            var list = new List<int>() { 1, 2, 3, 4, 4, 4, 5, 6, 7, 8, 9, 9, 9, 9, 8 };

            Console.WriteLine($"Longest sequence:\nInput array: {string.Join(", ", list)}");
            Console.WriteLine("Longest (first) sequence of equal numbers:");

            var longestSequence = ExtractLongestSubsequenceOfEqualNumbers(list);
            foreach (var element in longestSequence)
            {
                Console.WriteLine(element);
            }

            // Write a program that removes from given sequence all negative numbers.
            var listWithNegativeNumbers = new List<int>() { -1, -2, 132, 23, 23, -5, 2423, -2312, -3, 2 };

            Console.WriteLine($"\nRemove negative integers:\nInputArray: {string.Join(", ", listWithNegativeNumbers)}");
            Console.WriteLine("Resulting collection:");

            RemoveAllNegativeIntegers(listWithNegativeNumbers);
            foreach (var element in listWithNegativeNumbers)
            {
                Console.WriteLine(element);
            }

            // Write a program that removes from given sequence all numbers that occur odd number of times.
            var listWithRepeatingNumbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Console.WriteLine($"\nRemove odd occurring integers:\nInputArray: {string.Join(", ", listWithRepeatingNumbers)}");
            Console.WriteLine("Resulting collection:");

            RemoveAllOddOccurringElements(listWithRepeatingNumbers);
            foreach (var element in listWithRepeatingNumbers)
            {
                Console.WriteLine(element);
            }
        }

        public static void RemoveAllOddOccurringElements(List<int> list)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (var element in list)
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

            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key] % 2 != 0)
                {
                    list.RemoveAll(x => x == key);
                }
            }
        }

        public static void RemoveAllNegativeIntegers(List<int> list)
        {
            list.RemoveAll(x => x < 0);
        }

        public static List<int> ExtractLongestSubsequenceOfEqualNumbers(List<int> inputList)
        {
            var resultList = new List<int>();
            var bestNumber = inputList[0];
            var repetions = 1;
            for (var i = 1; i < inputList.Count; i++)
            {
                if (inputList[i] == inputList[i - 1])
                {
                    bestNumber = inputList[i];
                    repetions++;
                }
                else
                {
                    if (i != 1 && repetions > resultList.Count)
                    {
                        resultList.Clear();
                        for (int j = 0; j < repetions; j++)
                        {
                            resultList.Add(bestNumber);
                        }
                    }

                    repetions = 1;
                }
            }

            if (repetions > resultList.Count)
            {
                resultList.Clear();
                for (int j = 0; j < repetions; j++)
                {
                    resultList.Add(bestNumber);
                }
            }

            return resultList;
        }
    }
}
