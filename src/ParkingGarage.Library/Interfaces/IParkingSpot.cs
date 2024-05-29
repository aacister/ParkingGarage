using ParkingGarage.Library.Enums;

namespace ParkingGarage.Library.Interfaces;

public interface IParkingSpot{
    int Id { get;  }
    ParkingSpotStatusEnum Status { get; set; }
}

