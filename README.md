# Low Level Design Practice

A collection of low-level design implementations exploring system design concepts, OOP principles, and design patterns in C#.

## Overview

This repository contains various system design projects implemented from scratch, focusing on:

- Object-Oriented Design (OOP) principles
- SOLID principles
- Design patterns (Strategy, Factory, Singleton, etc.)
- System architecture and scalability
- Real-world problem-solving

## Projects

### [ParkingLot](./ParkingLot/)

A comprehensive parking lot management system that demonstrates:

- **Models**: Vehicle types (Car, Motorcycle, Truck) and parking spot types (Regular, Compact, Oversized)
- **Services**: Parking management, fare calculation, and ticket generation
- **Strategies**: Dynamic pricing using the Strategy pattern for peak/off-peak hours
- **Design Patterns**: Strategy pattern, Factory pattern, and encapsulation

**Key Features:**

- Multi-level parking lot support
- Vehicle entry/exit tracking
- Dynamic fare calculation
- Parking spot availability management

## Project Structure

```
Low Level Design/
├── .gitignore              # Global C# ignores
├── .gitattributes          # Line ending configuration
├── README.md               # This file
└── ParkingLot/             # Parking lot system project
    ├── Models/             # Data models
    │   ├── ParkingSpot/    # Spot types
    │   ├── Vehicle/        # Vehicle types
    │   └── Ticket.cs       # Ticket model
    ├── Services/           # Business logic
    │   ├── ParkingManager.cs
    │   ├── ParkingLot.cs
    │   └── FareCalculator.cs
    ├── Strategies/         # Strategy implementations
    │   ├── IFareStrategy.cs
    │   ├── BaseFareStrategy.cs
    │   └── PeakHoursFareStrategy.cs
    ├── Program.cs
    ├── ParkingLot.csproj
    └── README.md
```

## Getting Started

### Prerequisites

- .NET 10.0 or higher
- Visual Studio Code or Visual Studio
- Git

### Running a Project

```bash
# Navigate to the project directory
cd ParkingLot

# Run the application
dotnet run

# Build the project
dotnet build

# Run tests (if available)
dotnet test
```

## Technology Stack

- **Language**: C# 12+
- **Framework**: .NET 10.0+
- **Architecture**: Object-Oriented Design

## Design Patterns Used

### Parking Lot System

- **Strategy Pattern**: For different fare calculation strategies
- **Factory Pattern**: For creating parking spots and vehicles
- **Encapsulation**: Data hiding and abstraction
- **Interface Segregation**: Separate interfaces for different concerns

## Contributing

To add a new low-level design project:

1. Create a new directory at the root level
2. Add a `README.md` describing the project
3. Implement using SOLID principles and design patterns
4. Update this root README with the project details

## Resources

### Design Principles

- SOLID Principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion)
- DRY (Don't Repeat Yourself)
- YAGNI (You Aren't Gonna Need It)

### Learning References

- Refactoring and Design Patterns
- Clean Code practices
- System Design interviews

## Git Workflow

This repository uses a centralized git structure with:

- Root-level `.gitignore` applying to all projects
- `.gitattributes` for consistent line endings across platforms
- All projects tracked in a single repository

## License

This repository is for educational purposes. Feel free to use and modify for learning.

## Author

Arvind - Low Level Design Practice Repository
