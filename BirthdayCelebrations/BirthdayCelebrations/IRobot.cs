using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonInfo
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
