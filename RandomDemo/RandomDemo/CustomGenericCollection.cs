using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class CustomGenericCollection<T>
    {
        private T[] values;

        public CustomGenericCollection()
        { 
        this.values = new T[4];
        }

        public int Count { get; private set; }

        public void Add(T value) 
        {
            if (this.Count == this.values.Length) 
            { 
                T[] array = new T[this.values.Length * 2];

                for (int i = 0; i < this.values.Length; i++)
                { 
                    array[i] = this.values[i];
                }

                this.values = array;
            }

            this.values[this.Count] = value;
            this.Count++;
        }

        public void Remove()
        {
            T[] array = new T[this.values.Length];

            for (int i = 0; i < this.Count - 1; i++)
            {
                array[i] = this.values[i];
            }

            this.values = array;

            this.Count--;
        }

        public T[] Print() 
        {
            T[] array = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.values[i];
            }

            return array;
        }
    }
}
