using System;
using ParkingLot.Models.Vehicle;

namespace ParkingLot.Models.ParkingSpot
{
    public class CompactSpot : IParkingSpot
    {
        private int spotNumber;
        private IVehicle? parkedVehicle;

        public CompactSpot(int spotNumber)
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
            if (vehicle.GetSize() == VehicleSize.SMALL)
            {
                parkedVehicle = vehicle;
            }
            else
            {
                throw new InvalidOperationException("Vehicle size not suitable for Compact Spot.");
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
            return VehicleSize.SMALL;
        }
    }
}