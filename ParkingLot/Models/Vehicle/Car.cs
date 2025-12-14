using System;

namespace ParkingLot.Models.Vehicle
{
    public class Car : IVehicle
    {
        private string licensePlate;

        public Car(string licensePlate)
        {
            this.licensePlate = licensePlate;
        }

        public string GetLicensePlate()
        {
            return licensePlate;
        }

        public VehicleSize GetSize()
        {
            return VehicleSize.MEDIUM;
        }
    }
}