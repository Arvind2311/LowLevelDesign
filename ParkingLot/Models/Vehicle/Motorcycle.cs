using System;

namespace ParkingLot.Models.Vehicle
{
    public class Motorcycle : IVehicle
    {
        private string licensePlate;

        public Motorcycle(string licensePlate)
        {
            this.licensePlate = licensePlate;
        }

        public string GetLicensePlate()
        {
            return licensePlate;
        }

        public VehicleSize GetSize()
        {
            return VehicleSize.SMALL;
        }
    }
}