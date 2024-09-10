using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallReflectionDemo.Engines
{
    public class FoldingEngine : IEngine
    {
        public string work(string task)
        {
            return $"I am folding all the things on the {task} task.";
        }
    }
}
