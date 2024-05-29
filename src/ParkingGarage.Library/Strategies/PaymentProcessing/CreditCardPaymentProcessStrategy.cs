using ParkingGarage.Library.Interfaces;

namespace ParkingGarage.Library.Strategies.PaymentProcessing;

public class CreditCardPaymentProcessStrategy : IPaymentProcessingStrategy
{
    private readonly ILogger _logger;

    public CreditCardPaymentProcessStrategy(ILogger logger){
        _logger = logger;
    }
    public void Process(int amount)
    {
        _logger.Log($"Processed credit card payment with amount: {amount}");
    }
}
