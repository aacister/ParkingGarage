namespace ParkingGarage.Library.Interfaces;

public interface IPaymentProcessingStrategy
{
    void Process(int amount);
}
