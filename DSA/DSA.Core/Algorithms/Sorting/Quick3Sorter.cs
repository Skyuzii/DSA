namespace DSA.Core.Algorithms.Sorting;

public static class Quick3Sorter
{
    private static Random Rnd = new Random();
    
    public static IList<T> Quick3Sort<T>(this IList<T> list)
    {
        var comparer = Comparer<T>.Default;

        Shell(list);
        
        return Quick3Sort(list, 0, list.Count - 1, comparer);
    }

    private static void Shell<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var rndIndex = Rnd.Next(0, i);

            (list[i], list[rndIndex]) = (list[rndIndex], list[i]);
        }
    }

    private static IList<T> Quick3Sort<T>(this IList<T> list, int lower, int high, IComparer<T> comparer)
    {
        if (lower >= high)
        {
            return list;
        }
        
        var pivotIndex = lower;
        var left = lower + 1;
        var right = high;

        while (left <= right)
        {
            var comparerRes = comparer.Compare(list[left], list[pivotIndex]);
            if (comparerRes < 0)
            {
                Swap(pivotIndex++, left++);
            }
            else if (comparerRes > 0)
            {
                Swap(left, right--);
            }
            else
            {
                left++;
            }
        }

        Quick3Sort(list, lower, pivotIndex - 1, comparer);
        Quick3Sort(list, right + 1, high, comparer);

        void Swap(int i, int j)
        {
            (list[i], list[j]) = (list[j], list[i]);
        }

        return list;
    }
}