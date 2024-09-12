using System.Collections;

namespace DSA.Core.Algorithms.Searching;

public static class QuickSelector
{
    private static Random Rnd = new Random();
    
    public static T QuickSelectSmallest<T>(this IList<T> list, int k)
    {
        k -= 1;
        
        var comparer = Comparer<T>.Default;

        Shell(list);

        int lower = 0;
        int high = list.Count - 1;

        while (lower < high)
        {
            var pivotIndex = Partition(list, lower, high, comparer);
            
            if (pivotIndex > k)
            {
                high = pivotIndex - 1;
            }
            else if (pivotIndex < k)
            {
                lower = pivotIndex + 1;
            }
            else
            {
                break;
            }
        }

        return list[k];
    }

    private static void Shell<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var rndIndex = Rnd.Next(0, i);

            (list[i], list[rndIndex]) = (list[rndIndex], list[i]);
        }
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