using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo.InheritanceAnimals
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        { 
            return this.Count == 0;
        }

        public Stack<string> AddRange(Stack<string> strings) 
        {
            while (strings.Count > 0) 
            { 
                this.Push(strings.Pop());
            }

            return this; 
        }

    }
}
