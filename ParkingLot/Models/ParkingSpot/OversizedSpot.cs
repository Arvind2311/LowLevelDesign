using System;
using ParkingLot.Models.Vehicle;

namespace ParkingLot.Models.ParkingSpot
{
    public class OversizedSpot : IParkingSpot
    {
        private int spotNumber;
        private IVehicle? parkedVehicle;

        public OversizedSpot(int spotNumber)
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
            if (vehicle.GetSize() == VehicleSize.LARGE)
            {
                parkedVehicle = vehicle;
            }
            else
            {
                throw new InvalidOperationException("Vehicle size not suitable for Oversized Spot.");
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
            return VehicleSize.LARGE;
        }
    }
}