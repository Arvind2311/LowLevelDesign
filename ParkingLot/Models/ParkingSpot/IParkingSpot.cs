using System;
using ParkingLot.Models.Vehicle;

namespace ParkingLot.Models.ParkingSpot
{
    public interface IParkingSpot
    {
        bool IsAvailable();
        void Occupy(IVehicle vehicle);
        void Vacate();
        int GetSpotNumber();
        VehicleSize GetSize();
    }
}