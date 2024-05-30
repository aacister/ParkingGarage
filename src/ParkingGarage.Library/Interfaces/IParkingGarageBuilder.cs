using ParkingGarage.Library.Models.Terminals;

namespace ParkingGarage.Library.Interfaces;

public interface IParkingGarageBuilder
{
    IEnumerable<EntryTerminal> GetEntryTerminals();
    IEnumerable<ExitTerminal> GetExitTerminals();
    IParkingAssignmentStrategy GetAssignmentStrategy();
    IPaymentProcessingStrategy GetPaymentProcessingStrategy();


}
