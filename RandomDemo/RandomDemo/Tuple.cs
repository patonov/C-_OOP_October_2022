using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Tuple<X, Y>
    {
        public Tuple(X xItem, Y yItem) 
        { 
            this.Xvalue = xItem;
            this.Yvalue = yItem;
        }

        public X Xvalue { get; set; }
        public Y Yvalue { get; set; }

        public override string ToString() 
        {
            return $"{this.Xvalue} -> {Yvalue}";
        }
    }
}
