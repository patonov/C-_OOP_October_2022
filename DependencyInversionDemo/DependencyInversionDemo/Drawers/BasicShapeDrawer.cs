using DependencyInversionDemo.Drawers.Contracts;
using DependencyInversionDemo.Renders;
using DependencyInversionDemo.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionDemo.Drawers
{            
    public class BasicShapeDrawer : IShapeDrawer
    {
        private readonly IRender _render;

        public BasicShapeDrawer(IRender render) 
        { 
        this._render = render;
        }

        public virtual void DrawCircle(Circle circle)
        {
            _render.WriteLine("  +  ");
            _render.WriteLine(" +++ ");
            _render.WriteLine("+++++");
            _render.WriteLine(" +++ ");
            _render.WriteLine("  +  ");
        }

        public virtual void DrawRectangle(Rectangle rectangle)
        {
            _render.WriteLine("+++++");
            _render.WriteLine("+++++");
            _render.WriteLine("+++++");
            _render.WriteLine("+++++");
            _render.WriteLine("+++++");
        }
    }
}
