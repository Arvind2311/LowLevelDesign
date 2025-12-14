using System;
using System.Collections.Generic;
using ParkingLot.Models;
using ParkingLot.Strategies;

namespace ParkingLot.Services
{
    public class FareCalculator
    {
        List<IFareStrategy> fareStrategies;
        
        public FareCalculator(List<IFareStrategy> strategies)
        {
            fareStrategies = strategies;
        }

        public decimal CalculateFare(Ticket ticket)
        {
            decimal totalFare = 0;
            foreach (var strategy in fareStrategies)
            {
                totalFare = strategy.CalculateFare(ticket, totalFare);
            }
            return totalFare;
        }
    }
}