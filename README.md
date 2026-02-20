# 🅿️ Parking Garage System

A parking garage management system built with C# and .NET, demonstrating clean architecture and classic design patterns. The system handles vehicle entry/exit, intelligent spot assignment based on proximity to terminals, and multiple payment processing strategies.

## Projects

| Project | Description |
|---|---|
| `ParkingGarage.Library` | Core domain logic, models, interfaces, and strategies |
| `ParkingGarageConsole` | Console host application with configuration and DI wiring |

## Architecture & Design Patterns

### Builder Pattern
`ParkingGarageBuilder` constructs the garage and its components — entry terminals, exit terminals, and strategy implementations — decoupling object creation from the rest of the system.

### Strategy Pattern
Two interchangeable strategy families allow runtime behavior swapping:

- **Parking Assignment** (`IParkingAssignmentStrategy`) — determines which spot to assign a vehicle
- **Payment Processing** (`IPaymentProcessingStrategy`) — supports Cash and Credit Card processing

### Singleton
`Garage` is implemented as a singleton to ensure a single shared garage instance across the application.

### Dependency Injection
All services are registered via `ServiceCollectionExtensions.AddLibraryServices()` using the ASP.NET Core DI container, keeping components loosely coupled and testable.

## Parking Assignment Strategy

The core assignment algorithm uses **min-heap priority queues** (one per terminal, per vehicle type) to find the closest available spot to a given entry terminal.

- A `Dictionary<int, Dictionary<string, PriorityQueue<IParkingSpot, int>>>` maps each terminal to a set of type-specific priority queues
- A `HashSet<int>` tracks currently available spot IDs
- **Time Complexity:** `O(k log n)` where `k` = number of terminals and `n` = number of parking spots

## Vehicle & Spot Types

The system supports four vehicle/spot classifications:

- `Compact`
- `Handicapped`
- `Large`
- `Motorcycle`

## Configuration

Garage parameters are driven by `appsettings.json`:

```json
{
  "ParkingGarageConfig": {
    "NoOfSpots": 100,
    "NoOfTerminals": 4,
    "TotalDistance": 500
  }
}
```

`ParkingGarageConfigOptions` is bound via the Options pattern (`IOptions<T>`), keeping configuration strongly typed and injectable.

## Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

### Run

```bash
git clone https://github.com/your-username/parking-garage.git
cd parking-garage
dotnet run --project src/ParkingGarageConsole
```

## Project Structure

```
ParkingGarage.sln
└── src/
    ├── ParkingGarage.Library/
    │   ├── Builder/
    │   ├── Enums/
    │   ├── Interfaces/
    │   ├── Loggers/
    │   ├── Models/
    │   │   ├── ParkingSpots/
    │   │   └── Terminals/
    │   └── Strategies/
    │       ├── ParkingAssignment/
    │       └── PaymentProcessing/
    └── ParkingGarageConsole/
```
