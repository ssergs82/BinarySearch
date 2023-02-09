namespace TestData;

public class DataGenerationParameters
{
    public int Size { get; set; }
    public bool Sorted { get; set; } = true;
    public int RangeStart { get; set; } = int.MinValue;
    public int RangeEnd { get; set; } = int.MaxValue;
    public bool CanHasDuplicates { get; set; } = true;
    public int GrowUpStep { get; set; } = 5;

    public override int GetHashCode()
    {
        return $"{Size}_{Sorted}_{RangeStart}_{RangeEnd}_{CanHasDuplicates}_{GrowUpStep}".GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as DataGenerationParameters);
    }

    public bool Equals(DataGenerationParameters obj)
    {
        return obj != null && 
            obj.Size == this.Size &&
            obj.Sorted == this.Sorted &&
            obj.RangeStart == this.RangeStart &&
            obj.RangeEnd == this.RangeEnd &&
            obj.CanHasDuplicates == this.CanHasDuplicates &&
            obj.GrowUpStep == this.GrowUpStep;
    }
}