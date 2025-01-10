using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public static class RecursiveBinarySearcher
    {
        public static int Search(int[] array, int n, int x)
        {

            if (array[n - 1] >= (array[0]))
            {
                int midle = (n / 2) + 1;


                if (array[midle] == x)
                {  
                    return midle; 
                }

                if (array[midle] > x)
                {
                   return Search(array, midle, x);
                }
                                
            }
            return -1;
        }

    }
}
