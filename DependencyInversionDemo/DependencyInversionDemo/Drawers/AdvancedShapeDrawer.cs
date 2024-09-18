using DependencyInversionDemo.Common;
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
    public class AdvancedShapeDrawer : BasicShapeDrawer
    {
        private ILogger _logger;

        public AdvancedShapeDrawer(IRender render, ILogger logger) : base(render)
        { 
        _logger = logger;
        }

        public override void DrawCircle(Circle circle)
        {
            _logger.Log("Drawing circle...");
            Console.WriteLine("  @  ");
            Console.WriteLine(" @@@ ");
            Console.WriteLine("@@@@@");
            Console.WriteLine(" @@@ ");
            Console.WriteLine("  @  ");
        }

        public override void DrawRectangle(Rectangle rectangle)
        {
            _logger.Log("Drawing rectangle...");
            Console.WriteLine("@@@@@");
            Console.WriteLine("@@@@@");
            Console.WriteLine("@@@@@");
            Console.WriteLine("@@@@@");
            Console.WriteLine("@@@@@");
        }
    }
}
