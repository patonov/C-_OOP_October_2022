using SmallReflectionDemo.Engines;
using System.Reflection;

namespace SmallReflectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Type> engineTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IEngine).IsAssignableFrom(t)).ToList();

            string? input = Console.ReadLine();

            Type? type = engineTypes.FirstOrDefault(t => t.Name == input);

            IEngine? engine = Activator.CreateInstance(type) as IEngine;

            if (engine != null) 
            { 
                Console.WriteLine("Yakooo"); 
            }


        }
    }
}
