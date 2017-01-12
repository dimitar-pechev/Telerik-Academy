using System;
using System.Collections.Generic;
using SortingAndSearchingAlgorithms.Interfaces;

namespace SortingAndSearchingAlgorithms.Sorters
{
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            var equalityComparer = Comparer<T>.Default;
            int i = left;
            int j = right;
            T pivot = collection[(left + right) / 2];

            while (i <= j)
            {
                while (equalityComparer.Compare(collection[i], pivot) < 0)
                {
                    i++;
                }

                while (equalityComparer.Compare(collection[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T oldValue = collection[i];
                    collection[i] = collection[j];
                    collection[j] = oldValue;

                    i++;
                    j--;
                }
            }
            
            if (left < j)
            {
                this.QuickSort(collection, left, j);
            }

            if (i < right)
            {
                this.QuickSort(collection, i, right);
            }
        }
    }
}
