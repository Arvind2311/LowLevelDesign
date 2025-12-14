using System;
using ParkingLot.Models.Vehicle;
using ParkingLot.Models.ParkingSpot;

namespace ParkingLot.Models
{
    public class Ticket
    {
        public string ticketId { get; private set; }
        public IVehicle vehicle { get; private set; }
        public IParkingSpot parkingSpot { get; private set; }
        public DateTime entryTime { get; private set; }
        public DateTime? exitTime { get; set; }

        public Ticket(IVehicle vehicle, IParkingSpot parkingSpot)
        {
            this.ticketId = Guid.NewGuid().ToString();
            this.vehicle = vehicle;
            this.parkingSpot = parkingSpot;
            this.entryTime = DateTime.Now;
            this.exitTime = null;
        }

        public decimal calculateParkingDurationInHours()
        {
            DateTime endTime = exitTime ?? DateTime.Now;
            TimeSpan duration = endTime - entryTime;
            return (decimal)duration.TotalSeconds;
        }
    }
}