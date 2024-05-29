using Microsoft.Extensions.DependencyInjection;
using ParkingGarage.Library.Factories;
using ParkingGarage.Library.Interfaces;
using ParkingGarage.Library.Loggers;
using ParkingGarage.Library.Strategies.ParkingAssignment;
using ParkingGarage.Library.Strategies.PaymentProcessing;

namespace ParkingGarage.Library
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLibraryServices(this IServiceCollection services)
        {
            
            services.AddTransient<ILogger, ConsoleLogger>();
            services.AddTransient<IParkingAssignmentStrategy, ParkingSpotStrategy>();
            services.AddTransient<IPaymentProcessingStrategy, CreditCardPaymentProcessStrategy>();
            services.AddTransient<IPaymentProcessingStrategy, CashPaymentProcessingStrategy>();
            services.AddSingleton<IParkingGarageFactory, ParkingGarageFactory>();
        }
    }
}