# Parking Lot Management System

A low-level design implementation of a parking lot management system in C# .NET 10.0.

**Part of:** Low Level Design Series

## 🎯 System Design

![Parking Lot Architecture](ParkingLot.svg)

## 📋 Overview

Manages vehicle parking with:
- Multiple vehicle types (Car, Motorcycle, Truck)
- Size-based spot allocation (Compact, Regular, Oversized)
- Dynamic fare calculation with strategy pattern
- Peak hour pricing (1.5x multiplier 8-10 AM, 5-7 PM)
- Ticket-based entry/exit system

## 📁 Project Structure

```
ParkingLot/
├── Models/
│   ├── Vehicle/        (Car, Motorcycle, Truck)
│   └── ParkingSpot/    (CompactSpot, RegularSpot, OversizedSpot)
├── Services/           (ParkingManager, FareCalculator)
├── Strategies/         (BaseFareStrategy, PeakHoursFareStrategy)
└── Program.cs
```

## 🚀 Quick Start

```bash
cd "D:\Low Level Design\ParkingLot"
dotnet build
dotnet run
```

## � Usage Example

```csharp
// Enter
IVehicle car = new Car("ABC123");
Ticket ticket = parkingLot.EnterVehicle(car);

// Exit
parkingLot.ExitVehicle(ticket);
// Output: "Vehicle has exited. Total Fare: $X.XX"
```

## 🚗 Vehicles & Pricing

| Vehicle | Size | Spot Type | Rate |
|---------|------|-----------|------|
| Motorcycle | SMALL | Compact (0-9) | $1/hr |
| Car | MEDIUM | Regular (10-19) | $2/hr |
| Truck | LARGE | Oversized (20-29) | $3/hr |

## 🎨 Design Patterns

- **Strategy Pattern** - Flexible fare calculation
- **Manager Pattern** - Centralized resource management
- **Factory Pattern** - Vehicle/spot creation

## 🧪 Features

- Normal operation (car, motorcycle, truck scenarios)
- Stress testing (capacity handling)
- Exception handling for full lots

## ⚙️ Key Classes

| Class | Purpose |
|-------|---------|
| `ParkingLot` | Main facade |
| `ParkingManager` | Vehicle-to-spot mapping |
| `FareCalculator` | Fare computation |
| `Ticket` | Parking session tracker |

## 🔄 Core Operations

| Operation | Time |
|-----------|------|
| Park Vehicle | O(n) |
| Unpark Vehicle | O(1) |
| Calculate Fare | O(m) |

*n = spots per category, m = fare strategies*

## 📝 Future Enhancements

- Waiting queue for full lots
- Cross-size parking (motorcycles in car spots)
- Database persistence
- Payment gateway integration
- Reservation system

---

**.NET Version:** 10.0 | **Language:** C# | **Date:** December 2025
