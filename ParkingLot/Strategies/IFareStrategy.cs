using System;
using ParkingLot.Models;

namespace ParkingLot.Strategies
{
    public interface IFareStrategy
    {
        decimal CalculateFare(Ticket ticket, decimal inputFare);
    }
}