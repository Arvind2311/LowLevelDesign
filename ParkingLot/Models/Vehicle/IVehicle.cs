using System;

namespace ParkingLot.Models.Vehicle
{
    public interface IVehicle
    {
        string GetLicensePlate();
        VehicleSize GetSize();
    }
}