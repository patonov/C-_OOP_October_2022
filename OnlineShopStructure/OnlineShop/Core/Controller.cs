using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>(); 
        }

        public string AddComponent(int computerId, int id, string componentType, 
            string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType != nameof(Motherboard) && componentType != nameof(CentralProcessingUnit)
                && componentType != nameof(PowerSupply) && componentType != nameof(RandomAccessMemory)
                && componentType != nameof(SolidStateDrive) && componentType != nameof(VideoCard))
            {
                throw new ArgumentException("Component type is invalid.");
            }

            IComponent component;

            if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else 
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            var target = this.computers.FirstOrDefault(x => x.Id == computerId);
            target.AddComponent(component);
            this.components.Add(component);

            return $"Component {component.GetType().Name} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computerType != nameof(DesktopComputer) && computerType != nameof(Laptop))
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer;

            if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, 
            decimal price, double overallPerformance, string connectionType)
        {
            if (this.peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == peripheralType);
            if (type == null)
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IPeripheral instance = (IPeripheral)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price, overallPerformance, connectionType });
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddPeripheral(instance);
            this.peripherals.Add(instance);
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            this.computers = this.computers.OrderByDescending(c => c.OverallPerformance).ThenBy(c => c.Price).ToList();
            IComputer computer = this.computers[0];
            if (computer.Price > budget)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var target = this.computers.FirstOrDefault(x => x.Id == id);
            string result = target.ToString();

            this.computers.Remove(target);

            return result;
        }

        public string GetComputerData(int id)
        {
              if (!this.computers.Any(x => x.Id == id))
                  {
                   throw new ArgumentException("Computer with this id does not exist.");
                   }

            var target = this.computers.FirstOrDefault(x => x.Id == id);

            return "zaebi"; //target.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var target = this.computers.FirstOrDefault(x => x.Id == computerId);           
            var componentTarget = target.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            target.RemoveComponent(componentType);

            int iDToReturn = componentTarget.Id;
            string typeToReturn = componentTarget.GetType().Name;

            this.components.Remove(componentTarget);

            return $"Successfully removed {typeToReturn} with id {iDToReturn}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            int id = peripheral.Id;
            computer.Peripherals.ToList().Remove(peripheral);
            this.peripherals.Remove(peripheral);
            return $"Successfully removed {peripheralType} with id {id}.";
        }
    }
}
