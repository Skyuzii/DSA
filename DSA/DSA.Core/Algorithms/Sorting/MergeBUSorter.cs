namespace DSA.Core.Algorithms.Sorting;

public static class MergeBUSorter
{
    public static IList<T> MergeBUSort<T>(this IList<T> list)
    {
        var workArray = list.ToArray();
        var comparer = Comparer<T>.Default;

        for (int step = 1; step < list.Count; step += step)
        {
            for (int lower = 0; lower < list.Count; lower += step + step)
            {
                MergeBUSort(list, workArray, lower, lower + step, Math.Min(lower + step + step, list.Count), comparer);
            }
        }

        return list;
    }

    private static void MergeBUSort<T>(IList<T> list, T[] workArray, int lower, int middle, int high, IComparer<T> comparer)
    {
        var left = lower;
        var right = middle;

        for (int i = left; i < high; i++)
        {
            workArray[i] = list[i];
        }
        
        for (int i = left; i < high; i++)
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
    }
}