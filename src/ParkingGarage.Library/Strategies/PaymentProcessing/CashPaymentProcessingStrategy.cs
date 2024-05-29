using ParkingGarage.Library.Interfaces;

namespace ParkingGarage.Library.Strategies.PaymentProcessing;

public class CashPaymentProcessingStrategy : IPaymentProcessingStrategy
{
    private readonly ILogger _logger;

    public CashPaymentProcessingStrategy(ILogger logger){
        _logger = logger;
    }
    public void Process(int amount)
    {
        _logger.Log($"Processed cash payment with amount: {amount}");
    }
}
