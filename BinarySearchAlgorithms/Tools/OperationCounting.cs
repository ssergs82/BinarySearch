namespace BinarySearchAlgorithms.Tools;

public class OperationCounting
{
    public static bool IncreaseNumberOfComparisons(Func<bool> compareAction, ref int numberOfComparisons)
    {
        numberOfComparisons++;
        return compareAction();
    }
}
