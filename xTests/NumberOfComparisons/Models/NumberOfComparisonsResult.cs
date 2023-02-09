namespace Tests.NumberOfComparisons.Models;

public class NumberOfComparisonsResult
{
    public string AlgorithName { get; set; }
    public bool IsImplemented { get; set; }
    public int ArraySize { get; set; }
    public int TotalComparisons { get; set; }
    public double AvgComparisons => (double)TotalComparisons / ArraySize;
}
