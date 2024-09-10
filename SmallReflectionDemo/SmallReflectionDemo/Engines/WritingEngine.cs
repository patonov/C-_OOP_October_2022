using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallReflectionDemo.Engines
{
    public class WritingEngine : IEngine
    {
        public string work(string task)
        {
            return $"I am writing what is on the {task} task.";
        }
    }
}
