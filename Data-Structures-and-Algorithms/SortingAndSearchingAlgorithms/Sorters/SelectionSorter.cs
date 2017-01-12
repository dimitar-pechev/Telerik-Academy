using System;
using System.Collections.Generic;
using SortingAndSearchingAlgorithms.Interfaces;

namespace SortingAndSearchingAlgorithms.Sorters
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
            {
                return;
            }

            var equalityComparer = Comparer<T>.Default;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                var currentElement = collection[i];
                int indexOfSmallestValueElement = i;
                bool smallerValueFound = false;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (equalityComparer.Compare(currentElement, collection[j]) > 0)
                    {
                        currentElement = collection[j];
                        indexOfSmallestValueElement = j;
                        smallerValueFound = true;
                    }
                }

                if (smallerValueFound)
                {
                    var oldValue = collection[i];
                    collection[i] = currentElement;
                    collection[indexOfSmallestValueElement] = oldValue;
                }

                smallerValueFound = false;
            }
        }
    }
}
