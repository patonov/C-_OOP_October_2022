using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class IntEnumerator : IEnumerator<int>
    {
        private int currentNumber = 0;

        public int Current => this.currentNumber;

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (++this.currentNumber > 30)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            this.currentNumber = 0;
        }
    }
}
