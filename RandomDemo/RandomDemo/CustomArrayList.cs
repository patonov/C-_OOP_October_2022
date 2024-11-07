using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class CustomArrayList
    {
        private const int INITIAL_CAPACITY = 4;

        private object[] arr;
        private int count;

        public CustomArrayList()
        {
            this.arr = new object[INITIAL_CAPACITY];
            this.count = 0;
        }

        public int Count
        {
            get => this.count;
            private set
            {
                this.count = value;
            }
        }

        public void Add(object item)
        {
            if (this.Count == arr.Length)
            {
                Resize();
            }
            arr[Count] = item;
            Count++;


            //Insert(this.Count, item);
        }

        public void Insert(int index, object item)
        {
            if (this.Count == this.arr.Length)
            {
                Resize();
            }

            for (int i = this.arr.Length - 1; i > index; i--)
            {
                this.arr[i] = this.arr[i - 1];
            }

            this.arr[index] = item;
            this.Count++;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (this.arr[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            this.arr = new object[INITIAL_CAPACITY];
            this.Count = 0;
        }

        public bool Contains(object item)
        {
            int index = IndexOf(item);

            return (index != -1);
        }

        public object this[int index]
        {
            get => this.arr[index];
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Bro, just type a valid index!");
                }

                this.arr[index] = value;
            }
        }

        public object Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Bro, just type a valid index!");
            }

            object item = this.arr[index];

            this.arr[index] = null;

            Shift(index);
            this.Count--;

            if (this.Count <= this.arr.Length / 2)
            {
                Shrink();
            }

            return item;
        }

        private void Shrink()
        {
            object[] copyArr = new object[this.arr.Length / 2];

            Array.Copy(this.arr, copyArr, this.arr.Length);
            
            this.arr = copyArr;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.arr.Length - 1; i++) 
            {
                this.arr[i] = this.arr[i + 1];
            }

            this.arr[this.Count - 1] = null;
        }

        public int Remove(object item)
        { 
            int index = IndexOf(item);

            if (index == -1)
            { 
            return -1;
            }
            
            Remove(index);
            return index;
        }

        private void Resize()
        {
            object[] copyArray = new object[this.arr.Length * 2];

            Array.Copy(this.arr, copyArray, this.arr.Length);

            this.arr = copyArray;
        }
    }
}
