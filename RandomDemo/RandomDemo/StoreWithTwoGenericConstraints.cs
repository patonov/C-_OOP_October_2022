using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class StoreWithTwoGenericConstraints<A, B> where A : struct where B : class
    {
        public A KeyParameter {get; set;}

        public B? ValueParameter {get; set;}
    }
}
