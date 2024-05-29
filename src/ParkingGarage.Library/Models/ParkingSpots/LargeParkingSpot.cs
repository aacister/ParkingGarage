using System.Data.Common;
using ParkingGarage.Library.Enums;
using ParkingGarage.Library.Interfaces;

namespace ParkingGarage.Library.Models.ParkingSpots;

public class LargeParkingSpot : IParkingSpot
{
    private readonly int _id;
    private readonly ParkingSpotStatusEnum _status;
    public LargeParkingSpot(int id,
    ParkingSpotStatusEnum status = ParkingSpotStatusEnum.Vacant){
        _id = id;
        _status = status;
    }
    public int Id { get { return _id;}}
     public ParkingSpotStatusEnum Status { get; set; }
}
