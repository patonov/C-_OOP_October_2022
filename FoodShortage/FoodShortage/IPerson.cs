using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonInfo
{
    public interface IPerson : IBuyer
    {
        string Name { get; }

        int Age { get; }
        
    }
}
