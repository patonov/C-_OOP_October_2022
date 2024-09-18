using DependencyInversionDemo.DI;
using DependencyInversionDemo.Drawers;
using DependencyInversionDemo.Drawers.Contracts;

namespace DependencyInversionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider diProvider = DependencyInjectionService.ConfigureService();

            Engine engine = (Engine)diProvider.GetService(typeof(Engine));

            engine.Run();
        }
    }
}
