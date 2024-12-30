using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public static class BubbleSort
    {

        public static void BubbleSorter(int[] numbers)
        {
            var isSorted = false;
            
            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        Swap(numbers, j - 1, j);
                        isSorted = false;
                    }
                }
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
