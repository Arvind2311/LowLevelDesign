using System;
using System.Collections.Generic;
using ParkingLot.Models.Vehicle;
using ParkingLot.Models.ParkingSpot;

namespace ParkingLot.Services
{
    public class ParkingManager
    {
        Dictionary<VehicleSize, List<IParkingSpot>> availableSpots;
        Dictionary<IVehicle, IParkingSpot> vehicleToSpotMap;

        public ParkingManager(Dictionary<VehicleSize, List<IParkingSpot>> availableSpots)
        {
            this.availableSpots = availableSpots;
            this.vehicleToSpotMap = new Dictionary<IVehicle, IParkingSpot>();
        }

        private IParkingSpot FindSpotForVehicle(IVehicle vehicle)
        {
            VehicleSize size = vehicle.GetSize();
            if (availableSpots.ContainsKey(size))
            {
                foreach (var spot in availableSpots[size])
                {
                    if (spot.IsAvailable())
                    {
                        return spot;
                    }
                }
            }
            throw new InvalidOperationException("No available spots for this vehicle size.");
        }

        public IParkingSpot ParkVehicle(IVehicle vehicle)
        {
            IParkingSpot spot = FindSpotForVehicle(vehicle);
            spot.Occupy(vehicle);
            vehicleToSpotMap[vehicle] = spot;
            return spot;
        }

        public void UnparkVehicle(IVehicle vehicle)
        {
            if (vehicleToSpotMap.ContainsKey(vehicle))
            {
                IParkingSpot spot = vehicleToSpotMap[vehicle];
                spot.Vacate();
                vehicleToSpotMap.Remove(vehicle);
            }
            else
            {
                throw new InvalidOperationException("Vehicle is not parked.");
            }
        }
    }
}