namespace DSA.Core.Algorithms.Sorting;

public static class ShellSorter
{
    public static IList<T> ShellSort<T>(this IList<T> list)
    {
        var comparer = Comparer<T>.Default;

        var h = 1;

        while (h < list.Count / 3)
        {
            h = 3 * h + 1; // 1, 4, 13, 40, 121...
        }

        while (h >= 1)
        {
            for (int i = h; i < list.Count; i++)
            {
                for (int j = i - h; j >= h && comparer.Compare(list[j], list[j + h]) > 0; j -= h)
                {
                    (list[j], list[j + h]) = (list[j + h], list[j]);
                }
            }

            h /= 3;
        }

        return list;
    }
}