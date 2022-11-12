using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirCondModifier = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, BusAirCondModifier)
        {

        }

        public void TurnOnAirConditioner()
        {
            this.AirConditionModifier = BusAirCondModifier;
        }

        public void TurnOffAirConditioner()
        {
            this.AirConditionModifier = 0;
        }
    }
}
