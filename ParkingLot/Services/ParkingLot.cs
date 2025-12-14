using System;
using ParkingLot.Models;
using ParkingLot.Models.Vehicle;
using ParkingLot.Models.ParkingSpot;

namespace ParkingLot.Services
{
    public class ParkingLot
    {
        ParkingManager parkingManager;

        FareCalculator fareCalculator;

        public ParkingLot(ParkingManager parkingManager, FareCalculator fareCalculator)
        {
            this.parkingManager = parkingManager;
            this.fareCalculator = fareCalculator;
        }

        public Ticket EnterVehicle(IVehicle vehicle)
        {
            IParkingSpot spot = parkingManager.ParkVehicle(vehicle);
            Ticket ticket = new Ticket(vehicle, spot);
            return ticket;
        }

        public void ExitVehicle(Ticket ticket)
        {
            ticket.exitTime = DateTime.Now;
            parkingManager.UnparkVehicle(ticket.vehicle);
            decimal fare = fareCalculator.CalculateFare(ticket);
            // Process payment with the calculated fare

            Console.WriteLine($"Vehicle with Ticket ID: {ticket.ticketId} has exited. Total Fare: {fare:C}");
        }
    }
}