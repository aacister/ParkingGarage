using Microsoft.Extensions.Options;
using ParkingGarage.Library.Enums;
using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Models.ParkingSpots;

namespace ParkingGarage.Library.Strategies.ParkingAssignment;

public class ParkingSpotStrategy : IParkingAssignmentStrategy
{

    private readonly int _noOfSpots;
    private readonly int _noOfTerminals;

    private readonly int _totalDistance;
    private readonly ILogger _logger;
    private readonly Dictionary<int, List<int>> spotDistanceMap = new();

    private readonly PriorityQueue<IParkingSpot, int> _compactSpotPQ = new();
    private readonly PriorityQueue<IParkingSpot, int> _handicappedSpotPQ = new();
    private readonly PriorityQueue<IParkingSpot, int> _largeSpotPQ = new();
    private readonly PriorityQueue<IParkingSpot, int> _motorcycleSpotPQ = new();
    private readonly Dictionary<string, PriorityQueue<IParkingSpot, int>> _spotTypeToPQMap = new();
    private readonly Dictionary<int, Dictionary<string, PriorityQueue<IParkingSpot, int>>> _terminalToPriorityQueueMap = new();
    private readonly HashSet<int> _availableParkingSpots = new();
   

    public ParkingSpotStrategy(
        ILogger logger,
        IOptions<ParkingGarageConfigOptions> options
    )
    {
        _noOfSpots = options?.Value?.NoOfSpots ?? 1;
        _noOfTerminals = options?.Value?.NoOfTerminals ?? 1;
        _totalDistance = options?.Value?.TotalDistance ?? 500;
        _logger = logger;

        Initialize();
    }

    private void Initialize()
    {

        //create spots, and populate spotDistanceMap with distances to terminals
        for (var i = 1; i <= _noOfSpots; i++)
        {
            CalculateSpotDistanceMap(i, _noOfTerminals, _totalDistance);
        }

        PopulateSpotTypeToPQMap();

        foreach (KeyValuePair<int, List<int>> entry in spotDistanceMap)
        {
            // do something with entry.Value or entry.Key
            var spotId = entry.Key;
            var distanceToTerminalList = entry.Value;
            var spot = SetParkingSpot(spotId);
            _availableParkingSpots.Add(spot.Id);

            for (var k = 0; k < distanceToTerminalList.Count; k++)
            {
                //add parking spot to every terminal's min heap
                // min heap for each parking spot type
                var terminalId = k + 1;
                var terminalDistance = distanceToTerminalList[k];
                var spotType = spot.GetType();
                if (spotType == typeof(LargeParkingSpot))
                {
                    _largeSpotPQ.Enqueue(spot, terminalDistance);
                    
                }
                else if (spotType == typeof(CompactParkingSpot))
                {
                    _compactSpotPQ.Enqueue(spot, terminalDistance);

                }
                else if (spotType == typeof(HandicappedParkingSpot))
                {
                    _handicappedSpotPQ.Enqueue(spot, terminalDistance);
                   
                }
                else
                {
                    _motorcycleSpotPQ.Enqueue(spot, terminalDistance);
                }

                _terminalToPriorityQueueMap.Add(terminalId, _spotTypeToPQMap);
            }

        }
    }

   
    public IParkingSpot? GetParkingSpot(ITerminal terminal, VehicleTypeEnum vehicle)
    {
        if (_availableParkingSpots.Count <= 0)
        {
            _logger.Log("No more vacancies");
        }
   
        //Find closest spot to terminal
        var spotTypeToPqDict = _terminalToPriorityQueueMap[terminal.Id];
        var pq = spotTypeToPqDict[vehicle.ToString()];
        if(pq.Count > 0){
            IParkingSpot closestSpot = pq.Dequeue();
            closestSpot.Status = ParkingSpotStatusEnum.Occupied;
            _availableParkingSpots.Remove(closestSpot.Id);
            return closestSpot;
        }
        return null;

    }

    public void ReleaseParkingSpot(IParkingSpot spot)
    {
        _availableParkingSpots.Add(spot.Id);
        spot.Status = ParkingSpotStatusEnum.Vacant;

    }

     private void CalculateSpotDistanceMap(int spotId, int terminalCnt, int distance)
    {
        //Factors of totalDistance will be distance
        //map spot id to list of terminal distances where index + 1 is terminal Id

        if (distance < _totalDistance && terminalCnt > 0)
        {
            if (_totalDistance % distance == 0)
            {
                if (spotDistanceMap[spotId] != null)
                {
                    spotDistanceMap[spotId].Add(distance);
                }
                else
                {
                    spotDistanceMap.Add(spotId, new List<int>(distance));
                }
            }
            terminalCnt--;
            CalculateSpotDistanceMap(spotId, terminalCnt, distance + 1);
        }

    }

     private static IParkingSpot SetParkingSpot(int i)
    {

        var spotMod = i % 4;
        if (spotMod == 0)
        {
            return new LargeParkingSpot(i);
        }
        else if (spotMod == 1)
        {
            return new CompactParkingSpot(i);
        }
        else if (spotMod == 2)
        {
            return new HandicappedParkingSpot(i);
        }
        else
        {
            return new MotorcycleParkingSpot(i);
        }
    }

    private  void PopulateSpotTypeToPQMap(){
        _spotTypeToPQMap[typeof(HandicappedParkingSpot).ToString()] = _handicappedSpotPQ;
        _spotTypeToPQMap[typeof(CompactParkingSpot).ToString()] = _compactSpotPQ;
        _spotTypeToPQMap[typeof(LargeParkingSpot).ToString()] = _largeSpotPQ;
        _spotTypeToPQMap[typeof(MotorcycleParkingSpot).ToString()] = _motorcycleSpotPQ;

    }

}

