namespace DSA.Core.Algorithms.Sorting;

public static class MergeSorter
{
    public static IList<T> MergeSort<T>(this IList<T> list)
    {
        var comparer = Comparer<T>.Default;
        var workArray = new T[list.Count];

        return list.MergeSort(workArray, 0, workArray.Length, comparer);
    }

    private static IList<T> MergeSort<T>(this IList<T> list, T[] workArray, int lower, int high, IComparer<T> comparer)
    {
        if (high - lower < 2)
        {
            return list;
        }

        var middle = lower + (high - lower) / 2;

        MergeSort(list, workArray, lower, middle, comparer);
        MergeSort(list, workArray, middle, high, comparer);

        return Merge(list, workArray, lower, middle, high, comparer);
    }

    private static IList<T> Merge<T>(this IList<T> list, T[] workArray, int lower, int middle, int high, IComparer<T> comparer)
    {
        var left = lower;
        var right = middle;

        for (int i = lower; i < high; i++)
        {
            workArray[i] = list[i];
        }

        for (int i = lower; i < high; i++)
        {
            if (left < middle && (right >= high || comparer.Compare(workArray[left], workArray[right]) <= 0))
            {
                list[i] = workArray[left++];
            }
            else
            {
                list[i] = workArray[right++];
            }
        }

        return list;
    }
}