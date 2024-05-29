using ParkingGarage.Library.Interfaces;

namespace ParkingGarage.Library.Loggers;
public class ConsoleLogger : ILogger

    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }