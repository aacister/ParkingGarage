using ParkingGarage.Library.Enums;
using ParkingGarage.Library.Interfaces;

namespace ParkingGarage.Library.Models.ParkingSpots;

public class HandicappedParkingSpot : IParkingSpot
{
    private readonly int _id;
    private readonly ParkingSpotStatusEnum _status;
    public HandicappedParkingSpot(int id, ParkingSpotStatusEnum status = ParkingSpotStatusEnum.Vacant){
        _id = id;
        _status = status;
    }
    public int Id { get { return _id;}}
    public ParkingSpotStatusEnum Status { get; set; }
}
