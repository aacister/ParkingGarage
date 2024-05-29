using ParkingGarage.Library.Models.Terminals;

namespace ParkingGarage.Library.Interfaces;

public interface IParkingGarageFactory
{
    IList<EntryTerminal> GetEntryTerminals();
    IList<ExitTerminal> GetExitTerminals();
    IParkingAssignmentStrategy GetAssignmentStrategy();
    IPaymentProcessingStrategy GetPaymentProcessingStrategy();


}
