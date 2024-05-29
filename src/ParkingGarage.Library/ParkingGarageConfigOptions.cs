namespace ParkingGarage.Library;

public class ParkingGarageConfigOptions
{
    public const string ConfigKey = "PARKING_GARAGE_OPTIONS";
    public int NoOfSpots { get; set; }
    public int NoOfTerminals {get; set; }

    public int TotalDistance {get; set; }
}
