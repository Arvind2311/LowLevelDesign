using System;
using ParkingLot.Models;

namespace ParkingLot.Strategies
{
    public class PeakHoursFareStrategy : IFareStrategy
    {
        private const decimal PEAK_HOUR_MULTIPLIER = 1.5m;

        public decimal CalculateFare(Ticket ticket, decimal inputFare)
        {
            decimal fare = inputFare;
            if (IsPeakHour(ticket.entryTime))
            {
                fare = decimal.Multiply(fare, PEAK_HOUR_MULTIPLIER);
            }
            return fare;
        }

        private bool IsPeakHour(DateTime time)
        {
            int hour = time.Hour;
            return (hour >= 8 && hour < 10) || (hour >= 17 && hour < 19);
        }
    }
}