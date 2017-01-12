using System;
using System.Collections.Generic;
using SortingAndSearchingAlgorithms.Interfaces;

namespace SortingAndSearchingAlgorithms.Sorters
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Splitter(collection, 0, collection.Count - 1);
        }

        private void Splitter(IList<T> collection, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            var middle = (left + right) / 2;
            this.Splitter(collection, left, middle);
            this.Splitter(collection, middle + 1, right);
            this.Merger(collection, left, middle + 1, right);
        }

        private void Merger(IList<T> numbers, int left, int middle, int right)
        {
            var numbersCount = right - left + 1;
            var leftEnd = middle - 1;
            var position = left;
            var temp = new T[numbers.Count];

            while ((left <= leftEnd) && (middle <= right))
            {
                if (numbers[left].CompareTo(numbers[middle]) < 1)
                {
                    temp[position++] = numbers[left++];
                }
                else
                {
                    temp[position++] = numbers[middle++];
                }
            }

            while (left <= leftEnd)
            {
                temp[position++] = numbers[left++];
            }

            while (middle <= right)
            {
                temp[position++] = numbers[middle++];
            }

            for (var i = numbersCount - 1; i >= 0; i--)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
    }
}
