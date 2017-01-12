using System;
using System.Collections.Generic;

namespace SortingAndSearchingAlgorithms.Interfaces
{
    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(IList<T> collection);
    }
}
