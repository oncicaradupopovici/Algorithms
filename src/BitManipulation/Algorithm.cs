using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitManipulation
{
    public class Algorithm
    {
        
        public bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }
    }
}
