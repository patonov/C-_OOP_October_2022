using DependencyInversionDemo.Common;
using DependencyInversionDemo.Drawers;
using DependencyInversionDemo.Drawers.Contracts;
using DependencyInversionDemo.Renders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionDemo.DI
{
    public class DependencyInjectionService
    {
        public static IServiceProvider ConfigureService()
        {         
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IShapeDrawer, AdvancedShapeDrawer>();
            serviceCollection.AddTransient<Engine, Engine>();
            serviceCollection.AddTransient<IRender, ConsoleRender>();
            //serviceCollection.AddTransient<ILogger, DateLogger>(s => { return new DateLogger(4, 4, 2023); });
            serviceCollection.AddTransient<ILogger, Logger>();

            return serviceCollection.BuildServiceProvider();
        }


    }
}
