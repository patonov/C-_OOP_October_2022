using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionDemo.Renders
{
    public interface IRender
    {
        void Write(object obj);

        void WriteLine(object obj);
    }
}
