namespace DSA.Core.Algorithms.Sorting;

public static class SelectionSorter
{
    public static IList<T> SelectionSort<T>(this IList<T> list)
    {
        return list.SelectionSort(false);
    }
    
    public static IList<T> SelectionSortDesc<T>(this IList<T> list)
    {
        return list.SelectionSort(true);
    }
    
    private static IList<T> SelectionSort<T>(this IList<T> list, bool isDesc)
    {
        var comparer = Comparer<T>.Default;

        Func<T, T, bool> shouldSwapFunc = isDesc
            ? (T x, T y) => comparer.Compare(x, y) < 0
            : (T x, T y) => comparer.Compare(x, y) > 0;
        
        for (int i = 0; i < list.Count; i++)
        {
            var swapIndex = i;

            for (int j = i + 1; j < list.Count; j++)
            {
                if (shouldSwapFunc(list[swapIndex], list[j]))
                {
                    swapIndex = j;
                }
            }

            if (i != swapIndex)
            {
                (list[i], list[swapIndex]) = (list[swapIndex], list[i]);
            }
        }

        return list;
    }
}