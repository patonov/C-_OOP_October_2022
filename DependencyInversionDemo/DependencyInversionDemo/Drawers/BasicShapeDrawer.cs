using DependencyInversionDemo.Drawers.Contracts;
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
        public void DrawCircle(Circle circle)
        {
            Console.WriteLine("  +  ");
            Console.WriteLine(" +++ ");
            Console.WriteLine("+++++");
            Console.WriteLine(" +++ ");
            Console.WriteLine("  +  ");
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            Console.WriteLine("+++++");
            Console.WriteLine("+++++");
            Console.WriteLine("+++++");
            Console.WriteLine("+++++");
            Console.WriteLine("+++++");
        }
    }
}
