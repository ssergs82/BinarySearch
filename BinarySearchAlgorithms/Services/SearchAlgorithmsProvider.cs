namespace BinarySearchAlgorithms.Services;

public class SearchAlgorithmsProvider
{
    public List<T> GetSearchAlgorithms<T>(params Type[] ignoreList)
    {
        List<Type> types = GetSearchAlgorithmsTypes<T>(ignoreList);

        var result = types
            .Select(t => (T)Activator.CreateInstance(t))
            .ToList();

        return result;
    }

    public static List<Type> GetSearchAlgorithmsTypes<T>(params Type[] ignoreList)
    {
        Type type = typeof(T);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => (a.FullName.StartsWith("BinarySearchAlgorithms")))
            .SelectMany(s => s.GetTypes())
            .Where(p => !p.IsInterface && type.IsAssignableFrom(p) &&
                ignoreList.All(t => !(t.IsAssignableFrom(p) || (t.IsClass && t == p)))
            )
            .ToList();

        return types;
    }
}
