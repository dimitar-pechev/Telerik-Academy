using System;
using System.Collections.Generic;
using SortingAndSearchingAlgorithms.Interfaces;
using SortingAndSearchingAlgorithms.Sorters;

namespace SortingAndSearchingAlgorithms
{
    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; ++i)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new Quicksorter<T>());
            int left = 0;
            int right = this.items.Count - 1;

            while (left != right)
            {
                int middle = left + ((right - left) / 2);

                if (this.items[middle].CompareTo(item) < 0)
                {
                    left = middle + 1;
                }
                else if (this.items[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var random = new Random();

            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                var next = random.Next(0, i + 1);

                var helper = this.items[i];
                this.items[i] = this.items[next];
                this.items[next] = helper;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
