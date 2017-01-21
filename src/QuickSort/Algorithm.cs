using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Algorithm<T>
        where T: IComparable<T>
    {
        public IEnumerable<T> QuickSort(IEnumerable<T> input)
        {
            if (input.Count() == 0)
                yield break;

            if (input.Count() == 1)
            {
                yield return input.First();
                yield break;
            }

            var pivot = input.Last();
            var left = QuickSort(input.Where(i => i.CompareTo(pivot) < 0));
            var right = QuickSort(input.Where(i => i.CompareTo(pivot) > 0));

            foreach (var i in left)
                yield return i;

            yield return pivot;

            foreach (var i in right)
                yield return i;

        }
    }
}
