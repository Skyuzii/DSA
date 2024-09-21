namespace DSA.Core.Algorithms.Sorting;

public static class HeapSorter
{
    public static IList<T> HeapSort<T>(this IList<T> list)
    {
        var comparer = Comparer<T>.Default;

        return list.HeapSort(comparer);
    }

    private static IList<T> HeapSort<T>(this IList<T> list, IComparer<T> comparer)
    {
        for (int i = list.Count / 2; i >= 0; i--)
        {
            NodeHeapifyDown(list, i, list.Count, comparer);
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            (list[0], list[i]) = (list[i], list[0]);
            NodeHeapifyDown(list, 0, i, comparer);
        }

        return list;
    }

    private static void NodeHeapifyDown<T>(IList<T> list, int parentNodeIndex, int length, IComparer<T> comparer)
    {
        while (true)
        {
            var leftNodeIndex = parentNodeIndex * 2 + 1;
            var rightNodeIndex = parentNodeIndex * 2 + 2;

            if (leftNodeIndex >= length)
            {
                return;
            }

            var biggestNodeIndex = parentNodeIndex;

            if (comparer.Compare(list[biggestNodeIndex], list[leftNodeIndex]) < 0)
            {
                biggestNodeIndex = leftNodeIndex;
            }

            if (rightNodeIndex < length && comparer.Compare(list[biggestNodeIndex], list[rightNodeIndex]) < 0)
            {
                biggestNodeIndex = rightNodeIndex;
            }

            if (parentNodeIndex == biggestNodeIndex)
            {
                return;
            }

            (list[parentNodeIndex], list[biggestNodeIndex]) = (list[biggestNodeIndex], list[parentNodeIndex]);
            parentNodeIndex = biggestNodeIndex;
        }
    }
}