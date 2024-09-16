using DependencyInversionDemo.Drawers.Contracts;
using DependencyInversionDemo.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionDemo
{
    public class Engine
    {
        private IShapeDrawer _drawer;
        private List<Shape> shapes;

        public Engine(IShapeDrawer drawer) 
        { 
            _drawer = drawer;
            this.shapes = new List<Shape>();
            this.shapes.Add(new Circle());
            this.shapes.Add(new Rectangle());
        }

        public void Run() 
        {
            foreach (Shape shape in this.shapes) 
            {
                if (shape is Rectangle)
                {
                    _drawer.DrawRectangle(shape as Rectangle);
                }
                if (shape is Circle) 
                { 
                    _drawer.DrawCircle(shape as Circle);
                }
            }
        }
    }
}
