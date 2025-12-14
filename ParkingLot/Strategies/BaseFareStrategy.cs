using System;
using ParkingLot.Models;
using ParkingLot.Models.Vehicle;

namespace ParkingLot.Strategies
{
    public class BaseFareStrategy : IFareStrategy
    {
        private const decimal SMALL_VEHICLE_FARE = 1.0m;
        private const decimal MEDIUM_VEHICLE_FARE = 2.0m;
        private const decimal LARGE_VEHICLE_FARE = 3.0m;

        public decimal CalculateFare(Ticket ticket, decimal inputFare)
        {
            decimal fare = inputFare;
            decimal rate;
            switch (ticket.vehicle.GetSize())
            {
                case VehicleSize.SMALL:
                    rate = SMALL_VEHICLE_FARE;
                    break;
                case VehicleSize.MEDIUM:
                    rate = MEDIUM_VEHICLE_FARE;
                    break;
                case VehicleSize.LARGE:
                    rate = LARGE_VEHICLE_FARE;
                    break;
                default:
                    throw new ArgumentException("Unknown vehicle type");
            }
            rate = decimal.Add(fare,decimal.Multiply(rate, ticket.calculateParkingDurationInHours()));
            return rate;
        }
    }
}