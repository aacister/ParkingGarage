using Microsoft.Extensions.Options;
using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Models;
using ParkingGarage.Library.Models.Terminals;
using ParkingGarage.Library.Strategies.ParkingAssignment;

namespace ParkingGarage.Library.Builder;

public class ParkingGarageBuilder : IParkingGarageBuilder
{
    private readonly ILogger _logger;
    private readonly int _noOfSpots;
    private readonly int _noOfTerminals;

    public ParkingGarageBuilder(ILogger logger,
        IOptions<ParkingGarageConfigOptions> options){
        _logger = logger;
        _noOfSpots = options.Value.NoOfSpots;
        _noOfTerminals = options.Value.NoOfTerminals;
    }

    public IEnumerable<EntryTerminal> GetEntryTerminals()
    {
        _logger.Log("Getting Entry Terminals");
        List<EntryTerminal> terminals = new List<EntryTerminal>();
       // for(var i=0; i<_noOfTerminals; i++){
       //     var terminal = new EntryTerminal();
       //     terminals.Add(terminal))
       // }
        return terminals;
    }

    public IEnumerable<ExitTerminal> GetExitTerminals()
    {
        _logger.Log($"Getting Exit Terminals.");
        throw new NotImplementedException();
    }

    public IPaymentProcessingStrategy GetPaymentProcessingStrategy()
    {
        _logger.Log($"Getting Payment Processing Strategy.");
        throw new NotImplementedException();
    }

    public IParkingAssignmentStrategy GetAssignmentStrategy()
    {
        _logger.Log($"Getting Assignment Strategy.");
        throw new NotImplementedException();
    }
}
