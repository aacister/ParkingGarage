using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Models;
using ParkingGarage.Library.Models.Terminals;


namespace ParkingGarage.Library.Models;

public class Garage
{
        private static readonly Garage instance = new();

        private Garage() { }

        public static Garage GetInstance
        {
                get
                {
                        return instance;
                }
        }
        public IList<EntryTerminal> EntryTerminals { get; set; }
        public IList<ExitTerminal> ExitTerminals{ get; set; };
        
        


}
