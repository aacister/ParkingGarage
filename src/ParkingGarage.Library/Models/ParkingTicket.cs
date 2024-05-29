using System.Data.Common;
using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Models.ParkingSpots;

namespace ParkingGarage.Library;

public class ParkingTicket
{
   
    private readonly int _parkingSpotId;
    private readonly DateTime _issueTime;

    public ParkingTicket(
        int spotId
    ){
        _parkingSpotId = spotId;
        _issueTime = DateTime.Now;
    }
    public int ParkingSpotId { get; }    
    public DateTime IssueTime {get; set; }
}
