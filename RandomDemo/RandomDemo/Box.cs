using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Box<T>
    {
        private readonly List<T> internalList;

        public Box()
        {
            this.internalList = new List<T>();
        }

        public int Count { get; private set; }

        public void Add(T item) 
        { 
            this.internalList.Add(item);
            this.Count++;
        }

        public T Remove()
        {
            var obj = internalList[this.Count - 1];
            this.internalList.RemoveAt(this.Count - 1);
            this.Count--;
            return obj;
        }

    }
}
