using System;

namespace ParkingLot.Models.Vehicle
{
    public class Truck : IVehicle
    {
        private string licensePlate;

        public Truck(string licensePlate)
        {
            this.licensePlate = licensePlate;
        }

        public string GetLicensePlate()
        {
            return licensePlate;
        }

        public VehicleSize GetSize()
        {
            return VehicleSize.LARGE;
        }
    }
}