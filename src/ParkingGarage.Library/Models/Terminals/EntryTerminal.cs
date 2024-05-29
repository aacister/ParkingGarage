using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Models.ParkingSpots;

namespace ParkingGarage.Library.Models.Terminals;

public class EntryTerminal : ITerminal
{
    private readonly ILogger _logger;

    public EntryTerminal(ILogger logger){
        _logger = logger;
    }

   public int Id { get; set;}

    public  ParkingTicket GetTicket(IParkingSpot parkingSpot){
        var ticket = new ParkingTicket(parkingSpot.Id);
        _logger.Log($"Ticket received for parking Spot: {ticket.ParkingSpotId}");
        return ticket;
    }

    
}
