using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private object[] initialArray;
        private int count;

        public CustomStack() 
        { 
            this.initialArray = new object[initialCapacity];
            this.count = 0;
        }

        public int Count { get => this.count; }

        public void Push(object item)
        {
            if (this.initialArray.Length == this.Count)
            {
                object[] newArray = new object[this.initialArray.Length * 2];

                //for (int i = 0; i < this.initialArray.Length; i++) 
                //{
                //    newArray[i] = this.initialArray[i];
                //}

                Array.Copy(this.initialArray, newArray, this.Count);

                this.initialArray = newArray;                
            }
            this.initialArray[this.Count] = item;
            this.count++;
        }

        public object Pop() 
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            object item = this.initialArray[this.Count - 1];
            this.count--;
            return item;
        }

        public object Peek() 
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            object item = this.initialArray[this.Count - 1];
            return item;
        }
        
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++) 
            {
                action(this.initialArray[i]);
            }
        }
    }
}
