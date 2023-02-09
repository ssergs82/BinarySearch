namespace BinarySearchAlgorithms.Interfaces;

public interface IUniformBinarySearch : IArraySearch
{
    int Find(int[] array, int key, int[] deltas = null);
}
