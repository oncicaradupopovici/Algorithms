using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Algorithm<T>
        where T: IComparable<T>
    {
        public void QuickSort(IList<T> input) 
            => QuickSort(input, 0, input.Count - 1);


        private void QuickSort(IList<T> input, int lo, int hi)
        {
            if (lo < hi)
            {
                var pivot = Partition(input, lo, hi);
                QuickSort(input, lo, pivot - 1);
                QuickSort(input, pivot + 1, hi);
            }
        }

        private int Partition(IList<T> input, int lo, int hi)
        {
            var pivot = input[hi];
            var i = lo; //place for swapping
            for (var j = lo; j < hi; j++)
            {
                if (input[j].CompareTo(pivot) <=0)
                {
                    Swap(input, i, j);
                    i++;
                }
            }
            Swap(input, i, hi);

            return i;

        }

        private void Swap(IList<T> input, int i, int j)
        {
            if (i != j)
            {
                var aux = input[i];
                input[i] = input[j];
                input[j] = aux;
            }
        }
    }
}
