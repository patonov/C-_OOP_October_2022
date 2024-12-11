using System;
using System.Collections.Generic;
using System.Text;

using static BasicArrayList.GlobalConstants;

namespace BasicArrayList
{
    public class ArrayList
    {        
        private int[] items;

        public ArrayList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                int[] copy = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    copy[i] = this.items[i];
                }
                this.items = copy;
            }
            
            this.items[this.Count] = item;
            this.Count++;
        }

        public int CountFreePositions()
        {
            return this.items.Length - this.Count;
        }

        public void Cut(int count)
        {
            if (count > this.Count || count < 0)
            { 
                throw new ArgumentOutOfRangeException("The count you have entered is out of the range permitted.");
            }

            int itemsMustPersist = this.Count - count;

            int[] newArr = new int[itemsMustPersist];

            for (int i = 0; i < itemsMustPersist; i++) 
            { 
                newArr[i] = this.items[count + i];
            }

            this.items = newArr;
            this.Count = itemsMustPersist;
        }

        public int Change(int element, int newElement)
        {
            int index = -1;

            for (int i = 0; i < this.items.Length; i++) 
            {
                if (this.items[i] == element)
                {
                    this.items[i] = newElement;
                    index = i;
                    break;
                }
            }

            return index;
        }

    }
}
