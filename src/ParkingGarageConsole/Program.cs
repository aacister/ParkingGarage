using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingGarageConsole.Configuration;
using ParkingGarage.Library;

namespace ParkingGarageConsole;
class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");


        var configuration = builder.Build();

        var serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureOptions<ParkingGarageConfigOptionsSetup>();
        serviceCollection.AddLibraryServices();
        serviceCollection.BuildServiceProvider();

    }

}