using DependencyInversionDemo.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionDemo.Drawers.Contracts
{
    public interface IShapeDrawer
    {
        public void DrawCircle(Circle circle);

        public void DrawRectangle(Rectangle rectangle);
    }
}
