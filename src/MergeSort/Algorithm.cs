using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MergeSort
{
    public class Algorithm<T>
        where T : IComparable<T>
    {
        public IEnumerable<T> MergeSort(IEnumerable<T> input)            
        {
            if (input.Count() <= 1)
                return input;

            var middleIndex = input.Count() / 2;
            var left = MergeSort(input.Take(middleIndex)).ToArray();
            var right = MergeSort(input.Skip(middleIndex)).ToArray();

            return JoinSortedArrays(left, right);
        }


        private T[] JoinSortedArrays(T[] a, T[] b)
        {
            var result = new T[a.Length + b.Length];

            var ai = 0;
            var bi = 0;
            var ri = 0;

            var aIsDone = false;
            var bIsDone = false;

            while (!(aIsDone && bIsDone))
            {
                if(!aIsDone && (bIsDone || a[ai].CompareTo(b[bi]) < 0))
                {
                    result[ri] = a[ai];
                    ai++;
                    if (ai == a.Length)
                        aIsDone = true;
                }
                else
                {
                    result[ri] = b[bi];
                    bi++;
                    if (bi == b.Length)
                        bIsDone = true;
                }
                ri++;
            }

            return result;
        }
    }
}
