using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class RestrictedGenericClass<T, U> where T : U
    {
        public RestrictedGenericClass() { }

        public string GiveMessage(T first, U second) 
        {
            return $"{first.GetType().Name} {second.GetType().Name}";
        }
    }
}
