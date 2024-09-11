namespace DSA.Core.Algorithms.Sorting;

public static class QuickSorter
{
    private static readonly Random Rnd = new Random();

    public static IList<T> QuickSort<T>(this IList<T> list)
    {
        var comparer = Comparer<T>.Default;

        Shell(list);

        return QuickSort(list, 0, list.Count - 1, comparer);
    }

    private static void Shell<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var rndIndex = Rnd.Next(0, i);

            (list[i], list[rndIndex]) = (list[rndIndex], list[i]);
        }
    }

    private static IList<T> QuickSort<T>(this IList<T> list, int lower, int high, IComparer<T> comparer)
    {
        if (lower >= high)
        {
            return list;
        }

        var pivotIndex = Partition(list, lower, high, comparer);

        QuickSort(list, lower, pivotIndex - 1, comparer);
        QuickSort(list, pivotIndex + 1, high, comparer);

        return list;
    }

    private static int Partition<T>(this IList<T> list, int lower, int high, IComparer<T> comparer)
    {
        var left = lower;
        var right = high + 1;

        while (true)
        {
            while (comparer.Compare(list[++left], list[lower]) <= 0 && left < high)
            {
            }

            while (comparer.Compare(list[lower], list[--right]) <= 0 && right > lower)
            {
            }

            if (left >= right)
            {
                break;
            }

            (list[left], list[right]) = (list[right], list[left]);
        }

        (list[lower], list[right]) = (list[right], list[lower]);

        return right;
    }
}