using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class EqualityScale<T>
    {
        private T? left;
        private T? right;

        public EqualityScale(T left, T right)
        { 
            this.Left = left;
            this.Right = right;
        }

        public T? Left 
        { 
            get => this.left; 
            private set
            { 
                this.left = value; 
            }
        }

        public T? Right 
        { 
            get => this.right;
            private set
            { 
                this.right = value;
            }
        }

        public bool AreEqual()
        {
            if (this.Left!.Equals(this.Right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
