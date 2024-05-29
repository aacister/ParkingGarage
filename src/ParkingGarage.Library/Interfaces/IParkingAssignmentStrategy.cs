using ParkingGarage.Library.Enums;
using ParkingGarage.Library.Models.ParkingSpots;

namespace ParkingGarage.Library.Interfaces;

public interface IParkingAssignmentStrategy
{
    IParkingSpot? GetParkingSpot(ITerminal terminal, VehicleTypeEnum vehicle);
    void ReleaseParkingSpot(IParkingSpot spot);
}
