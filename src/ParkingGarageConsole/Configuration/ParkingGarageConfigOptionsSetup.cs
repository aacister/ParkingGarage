using Microsoft.Extensions.Configuration;
using ParkingGarage.Library;


namespace ParkingGarageConsole.Configuration;

public class ParkingGarageConfigOptionsSetup 
{
    private const string SectionName = "ParkingGarageConfig";
    private readonly IConfiguration _configuration;

    public ParkingGarageConfigOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ParkingGarageConfigOptions options)
    {
        _configuration
            .GetSection(SectionName)
            .Bind(options);
    }
}