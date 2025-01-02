using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class CustomQueue : IEnumerable
    {
        private const int initial_capacity = 4;
        private int startIndex;
        private int endIndex;
        private object[] objects;

        public CustomQueue() 
        { 
            this.objects = new object[initial_capacity];
        }

        public IEnumerator GetEnumerator()
        {
            return this.objects.GetEnumerator();
        }

        public int Count { get; private set; }
        public int Capacity { get => this.objects.Length; }

        public void Enqueue(object item)
        {
            if (this.Count >= this.objects.Length)
            {
                Grow();
            }
            
            this.objects[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.objects.Length;
            this.Count++;
        }

        private void Grow()
        {
            object[] newArr = new object[this.objects.Length * 2];
            CopyAllElementsTo(newArr);
            this.objects = newArr;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CopyAllElementsTo(object[] resultArray)
        {
            int sourceIndex = this.startIndex;
            int destinationIndex = 0;

            for (int i = 0; i < this.Count; i++)
            {
                resultArray[destinationIndex] = this.objects[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.objects.Length;
                destinationIndex++;
            }
        }

        public object Dequeue()
        {
            if (this.Count == 0)
            { 
                throw new InvalidOperationException("The queue is empty.");
            }

            var itemToReturn = this.objects[this.startIndex];
            startIndex = (startIndex + 1) % this.objects.Length;
            this.Count--;
            return itemToReturn;
        }

        public object Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var itemToReturn = this.objects[this.startIndex];
            return itemToReturn;
        }

        public object[] ToArray()
        { 
            object[] arrToReturn = new object[this.Count];
            CopyAllElementsTo(arrToReturn);
            return arrToReturn;
        }

        public void ForEach(Action<object> action)
        { 
            int initialIndex = this.startIndex;
            for (int i = initialIndex; i < this.Count; i++)
            {
                action(this.objects[i]);
            }
        }

        
    }
}
