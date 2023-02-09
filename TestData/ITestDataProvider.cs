namespace TestData;

public interface ITestDataProvider<T>
{
    public static int DefaultRangeStart
    {
        get
        {
            if (typeof(T) == typeof(short))
            {
                return short.MinValue;
            }

            return int.MinValue;
        }
    }

    public static int DefaultRangeEnd
    {
        get
        {
            if (typeof(T) == typeof(short))
            {
                return short.MaxValue;
            }

            return int.MaxValue;
        }
    }


    T[] Get(DataGenerationParameters dataGenerationParameters);
}
