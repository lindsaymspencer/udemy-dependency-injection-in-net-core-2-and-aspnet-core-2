using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConditionalResolve
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var collection = new ServiceCollection();

            collection.AddScoped<EuropeTaxCalculator>();
            collection.AddScoped<AustraliaTaxCalculator>();

            collection.AddScoped<Func<UserLocations, ITaxCalculator>>(
                ServiceProvider => key =>
                {
                    switch (key)
                    {
                        case UserLocations.Australia: return ServiceProvider.GetService<AustraliaTaxCalculator>();
                        case UserLocations.Europe: return ServiceProvider.GetService<EuropeTaxCalculator>();
                        default: return null;
                    }
                });

            collection.AddSingleton<Purchase>();

            var provider = collection.BuildServiceProvider();

            var purchase = provider.GetService<Purchase>();
            var totalCharge = purchase.Checkout(UserLocations.Australia);

            Console.WriteLine(totalCharge);
        }
    }
}
