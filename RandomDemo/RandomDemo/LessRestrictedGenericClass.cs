using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class LessRestrictedGenericClass<T> where T : BaseEmployeeClass
    {
        public string GiveMessage(T parameter)
        {
            return $"{parameter.GetType().Name}";
        }
    }
}
