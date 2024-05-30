using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Models;
using ParkingGarage.Library.Models.Terminals;


namespace ParkingGarage.Library.Models;

public class Garage
{
        private static readonly Garage instance = new();

        public static Garage GetInstance
        {
                get
                {
                        return instance;
                }
        }
        public IEnumerable<EntryTerminal> EntryTerminals { get; set; } = new List<EntryTerminal>();
        public IEnumerable<ExitTerminal> ExitTerminals { get; set; } = new List<ExitTerminal>();
        
        


}
