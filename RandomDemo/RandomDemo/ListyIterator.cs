using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> internalList;
        private int index;

        public ListyIterator() 
        { 
            this.internalList = new List<T>();
        }

        public void Create(params T[] inputValues) 
        {
            foreach (var value in inputValues) 
            { 
                this.internalList.Add(value);
            }
        }

        public bool Move()
        { 
            var hasNext = this.HasNext();
            if (hasNext) 
            { 
                this.index++;
            }
            return hasNext;
        }

        public bool HasNext() 
        {
            if (index >= 0 && index < this.internalList.Count - 1)
            { 
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (!this.internalList.Any())
            {
                throw new InvalidOperationException("No object in the collection.");
            }
            Console.WriteLine(this.internalList[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.internalList.Count; i++)
            { 
                yield return this.internalList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void PrintAll()
        {
            if (!this.internalList.Any())
            {
                throw new InvalidOperationException("No object in the collection.");
            }
            Console.WriteLine(string.Join(" ", this.internalList));
        }
    }
}
