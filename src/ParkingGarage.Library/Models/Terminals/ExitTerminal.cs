using ParkingGarage.Library.Interfaces;

namespace ParkingGarage.Library.Models.Terminals;

public class ExitTerminal : ITerminal
{
    private readonly IPaymentProcessingStrategy _paymentProcessingStrategy;
    private readonly ILogger _logger;

    public ExitTerminal(
        IPaymentProcessingStrategy paymentProcessingStrategy,
        ILogger logger){
       _paymentProcessingStrategy = paymentProcessingStrategy;
       _logger = logger;
    }

    public int Id {get; set;}
    public void AcceptTicket(ParkingTicket ticket){
        _logger.Log($"Ticket for parking spot {ticket.ParkingSpotId} accepted.");
    }
}
