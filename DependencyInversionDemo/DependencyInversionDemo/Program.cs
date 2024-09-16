using DependencyInversionDemo.Drawers;
using DependencyInversionDemo.Drawers.Contracts;

namespace DependencyInversionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            IShapeDrawer drawer = new AdvancedShapeDrawer();

            Engine engine = new Engine(drawer);

            engine.Run();
        }
    }
}
