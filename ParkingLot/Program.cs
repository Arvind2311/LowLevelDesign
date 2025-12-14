using System;
using System.Collections.Generic;
using ParkingLot.Models;
using ParkingLot.Models.ParkingSpot;
using ParkingLot.Models.Vehicle;
using ParkingLot.Strategies;
using ParkingLot.Services;
using ParkingLotService = ParkingLot.Services.ParkingLot;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Parking Lot Management System!");
            
            var parkingLot = InitializeParkingLot();
            
            RunNormalScenarios(parkingLot);
            RunStressTest(parkingLot);
            
            Console.WriteLine("\nThank you for using the Parking Lot Management System!");
        }

        static ParkingLotService InitializeParkingLot()
        {
            // Initialize parking spots
            var parkingSpots = InitializeParkingSpots();
            
            // Create parking manager
            ParkingManager parkingManager = new ParkingManager(parkingSpots);

            // Initialize fare calculation strategies
            List<IFareStrategy> fareStrategies = new List<IFareStrategy>()
            {
                new BaseFareStrategy(),
                new PeakHoursFareStrategy()
            };
            FareCalculator fareCalculator = new FareCalculator(fareStrategies);

            return new ParkingLotService(parkingManager, fareCalculator);
        }

        static Dictionary<VehicleSize, List<IParkingSpot>> InitializeParkingSpots()
        {
            List<IParkingSpot> compactSpots = CreateSpots(0, 10, (i) => new CompactSpot(i));
            List<IParkingSpot> regularSpots = CreateSpots(10, 20, (i) => new RegularSpot(i));
            List<IParkingSpot> oversizedSpots = CreateSpots(20, 30, (i) => new OversizedSpot(i));

            return new Dictionary<VehicleSize, List<IParkingSpot>>()
            {
                { VehicleSize.SMALL, compactSpots },
                { VehicleSize.MEDIUM, regularSpots },
                { VehicleSize.LARGE, oversizedSpots }
            };
        }

        static List<IParkingSpot> CreateSpots(int startIndex, int endIndex, Func<int, IParkingSpot> spotFactory)
        {
            List<IParkingSpot> spots = new List<IParkingSpot>();
            for (int i = startIndex; i < endIndex; i++)
            {
                IParkingSpot spot = spotFactory(i);
                Console.WriteLine($"Created parking spot {spot.GetSpotNumber()} of size {spot.GetSize()}");
                spots.Add(spot);
            }
            return spots;
        }

        static void RunNormalScenarios(ParkingLotService parkingLot)
        {
            ParkVehicleScenario(parkingLot, "Car", new Car("ABC123"), 2000, "--- Car Parking Scenario ---");
            ParkVehicleScenario(parkingLot, "Motorcycle", new Motorcycle("XYZ789"), 3000, "--- Motorcycle Parking Scenario ---");
            ParkVehicleScenario(parkingLot, "Truck", new Truck("TRK001"), 5000, "--- Truck Parking Scenario ---");
        }

        static void ParkVehicleScenario(ParkingLotService parkingLot, string vehicleType, IVehicle vehicle, int parkingDurationMs, string header)
        {
            Console.WriteLine($"\n{header}");
            Ticket ticket = parkingLot.EnterVehicle(vehicle);
            Console.WriteLine($"{vehicleType} with license plate {vehicle.GetLicensePlate()} parked. Ticket ID: {ticket.ticketId}");

            System.Threading.Thread.Sleep(parkingDurationMs);
            parkingLot.ExitVehicle(ticket);
        }

        static void RunStressTest(ParkingLotService parkingLot)
        {
            Console.WriteLine("\n--- STRESS TEST: Filling All Parking Spots ---");
            
            FillParkingCategory(parkingLot, "motorcycles", () => new Motorcycle($"MOTO{GetCount(0)}"), 10);
            FillParkingCategory(parkingLot, "cars", () => new Car($"CAR{GetCount(1)}"), 10);
            FillParkingCategory(parkingLot, "trucks", () => new Truck($"TRUCK{GetCount(2)}"), 10);

            TestOverflowScenarios(parkingLot);
            Console.WriteLine("\n--- Stress Test Complete ---");
        }

        static int _motorcycleCount = 0, _carCount = 0, _truckCount = 0;

        static string GetCount(int type)
        {
            return type switch
            {
                0 => (_motorcycleCount++).ToString("D3"),
                1 => (_carCount++).ToString("D3"),
                2 => (_truckCount++).ToString("D3"),
                _ => "000"
            };
        }

        static void FillParkingCategory(ParkingLotService parkingLot, string categoryName, Func<IVehicle> vehicleFactory, int count)
        {
            Console.WriteLine($"\nFilling {categoryName}...");
            for (int i = 0; i < count; i++)
            {
                try
                {
                    IVehicle vehicle = vehicleFactory();
                    Ticket ticket = parkingLot.EnterVehicle(vehicle);
                    Console.WriteLine($"✓ {vehicle.GetLicensePlate()} parked at spot {ticket.parkingSpot.GetSpotNumber()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Failed to park: {ex.Message}");
                }
            }
        }

        static void TestOverflowScenarios(ParkingLotService parkingLot)
        {
            Console.WriteLine("\n--- Attempting to park when all spots are FULL ---");
            
            TestOverflow(parkingLot, "motorcycle", new Motorcycle("MOTO999"));
            TestOverflow(parkingLot, "car", new Car("CAR999"));
            TestOverflow(parkingLot, "truck", new Truck("TRUCK999"));
        }

        static void TestOverflow(ParkingLotService parkingLot, string vehicleType, IVehicle vehicle)
        {
            Console.WriteLine($"\nAttempting to park {vehicleType}...");
            try
            {
                Ticket ticket = parkingLot.EnterVehicle(vehicle);
                Console.WriteLine($"✓ {vehicle.GetLicensePlate()} parked at spot {ticket.parkingSpot.GetSpotNumber()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ ERROR: {ex.Message}");
            }
        }
    }
}