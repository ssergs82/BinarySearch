namespace TestData.Randomize;

public class CustomRandom : Random
{
    private Random _rand;
    private int? _seed = null;

    public CustomRandom()
    {
        _rand = new Random();
    }
    public CustomRandom(int seed)
    {
        _seed = seed;
        _rand = new Random(Seed: seed);
    }

    public override int Next() => _rand.Next();
    
    public override int Next(int maxValue) => _rand.Next(maxValue);

    private int? prevNextElementByMinMax = null;
    public override int Next(int minValue, int maxValue)
    {
        var current = _rand.Next(minValue, maxValue);
        if(prevNextElementByMinMax.HasValue && minValue + 2 < maxValue && current == prevNextElementByMinMax)
        {
            _rand = _seed.HasValue ? new Random(_seed.Value) : new Random();
            current = _rand.Next(minValue, maxValue);
        }
        prevNextElementByMinMax = current;

        return current;
    }
  
    public override void NextBytes(byte[] buffer) => _rand.NextBytes(buffer);
  
    public override void NextBytes(Span<byte> buffer) => _rand.NextBytes(buffer);
  
    public override double NextDouble() => _rand.NextDouble();
}
