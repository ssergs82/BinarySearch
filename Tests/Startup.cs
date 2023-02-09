using BinarySearchAlgorithms.Implementation;
using BinarySearchAlgorithms.Implementations.Uniform;
using BinarySearchAlgorithms.Services;
using Microsoft.Extensions.DependencyInjection;
using TestData;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<UnSafePointerBasedBinarySearch>();
        services.AddSingleton<UnSafeMonoboundBinarySearch>();
        services.AddSingleton<UnSafeQuickDescentBinarySearch>();
        services.AddSingleton<CompareToMatchFirstBinarySearch>();
        services.AddSingleton<CompareToLessFirstBinarySearch>();
        services.AddSingleton<CompareToMoreFirstBinarySearch>();
        services.AddSingleton<SingleEqualCompareBinarySearch>();
        services.AddSingleton<LinearAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<LinearAndSingleEqualCompareBinarySearch>();
        services.AddSingleton<UniformBinarySearch>();
        services.AddSingleton<UniformBinaryInLineDeltaCalculation>();
        services.AddSingleton<LinearFor4ElementsAndSingleEqualCompareBinarySearch>();
        services.AddSingleton<LinearFor4ElementsAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<LinearFor5ElementsAndSingleEqualCompareBinarySearch>();
        services.AddSingleton<LinearFor5ElementsAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<LinearFor6ElementsAndSingleEqualCompareBinarySearch>();
        services.AddSingleton<LinearFor6ElementsAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<LinearFor7ElementsAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<LinearFor8ElementsAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<QuickDescentAndSingleEqualCompareBinarySearch>();
        services.AddSingleton<QuickDescentAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<QuickDescentAndLinearAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<QuickDescentAndLinearAndSingleEqualCompareBinarySearch>();
        services.AddSingleton<LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearch>();
        services.AddSingleton<LengthAdaptiveQuickDescentAndLinearAndCompareToMoreFirstBinarySearch2>();

        services.AddSingleton(typeof(DefaultTestDataProvider<>), typeof(DefaultTestDataProvider<>));
        services.AddSingleton<SearchAlgorithmsProvider>();
        services.AddLogging();
        services.AddSingleton<Startup>();

        services.BuildServiceProvider();
    }
}