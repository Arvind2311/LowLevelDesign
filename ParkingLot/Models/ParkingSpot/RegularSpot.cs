using System;
using ParkingLot.Models.Vehicle;

namespace ParkingLot.Models.ParkingSpot
{
    public class RegularSpot : IParkingSpot
    {
        private int spotNumber;
        private IVehicle? parkedVehicle;

        public RegularSpot(int spotNumber)
        {
            this.spotNumber = spotNumber;
            this.parkedVehicle = null;
        }

        public bool IsAvailable()
        {
            return parkedVehicle == null;
        }

        public void Occupy(IVehicle vehicle)
        {
            if (vehicle.GetSize() == VehicleSize.MEDIUM)
            {
                parkedVehicle = vehicle;
            }
            else
            {
                throw new InvalidOperationException("Vehicle size not suitable for Regular Spot.");
            }
        }

        public void Vacate()
        {
            parkedVehicle = null;
        }

        public int GetSpotNumber()
        {
            return spotNumber;
        }

        public VehicleSize GetSize()
        {
            return VehicleSize.MEDIUM;
        }
    }
}