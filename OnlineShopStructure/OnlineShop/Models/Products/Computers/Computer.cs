using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance 
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
            }
            
        }

        public override decimal Price
        {
            get
            {
               return base.Price + this.Components.Sum(x => x.Price) + this.Peripherals.Sum(x => this.Price);
            }
        
        }

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any() || this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            var target = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(target);
            return target;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any() || this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            var target = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(target);
            return target;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var comp in this.Components)
            {
                sb.AppendLine($"  {comp.GetType().Name}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(x => x.OverallPerformance)}):");
            foreach (var pere in this.Peripherals)
            {
                sb.AppendLine($"  {pere.GetType().Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
