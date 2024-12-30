using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class StoreWithGenericConstraint<T> where T : class
    {
        private T _storedValue; 

        public StoreWithGenericConstraint() 
        { 
        
        } 

        public T StoredValue { get { return _storedValue; } set { _storedValue = value; } }
    }
}
