using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            { 
            return "Race cannot be completed because both racers are not available!";
            }
            else if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo} wins the race! {racerOne} was not available to race!";
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne} wins the race! {racerTwo} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceOfWinning1 = 0;
            double chanceOfWinning2 = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinning1 = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            }
            else
            {
                chanceOfWinning1 = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinning2 = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
            }
            else
            {
                chanceOfWinning2 = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
            }

            IRacer winner;

            if (chanceOfWinning1 > chanceOfWinning2)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
