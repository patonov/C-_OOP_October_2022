using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallReflectionDemo.Engines
{
    public class SortingEngine : IEngine
    {
        public string work(string task)
        {
            return $"I am sorting what is on the {task} task.";
        }
    }
}
