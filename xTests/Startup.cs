using BinarySearchAlgorithms.Implementation;
using BinarySearchAlgorithms.Implementations.Uniform;
using BinarySearchAlgorithms.Interfaces;
using BinarySearchAlgorithms.Services;
using Microsoft.Extensions.DependencyInjection;
using TestData;

namespace Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var searchAlgorithmsTypes = SearchAlgorithmsProvider.GetSearchAlgorithmsTypes<IBinarySearch>();
        searchAlgorithmsTypes.ForEach(searchAlgorithmType =>
        {
            services.AddSingleton(searchAlgorithmType);
        });

        services.AddSingleton(typeof(DefaultTestDataProvider<>), typeof(DefaultTestDataProvider<>));
        services.AddSingleton<SearchAlgorithmsProvider>();
        services.AddLogging();
        services.AddSingleton<Startup>();

        services.BuildServiceProvider();
    }
}