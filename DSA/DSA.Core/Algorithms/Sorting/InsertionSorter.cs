namespace DSA.Core.Algorithms.Sorting;

public static class InsertionSorter
{
    public static IList<T> InsertionSort<T>(this IList<T> list)
    {
        var comparer = Comparer<T>.Default;
        
        for (int i = 1; i < list.Count; i++)
        {
            for (int j = i - 1; j >= 0 && comparer.Compare(list[j], list[j + 1]) > 0; j--)
            {
                (list[j + 1], list[j]) = (list[j], list[j + 1]);
            }
        }

        return list;
    }
}


















// for (int j = i - 1; j >= 0 && comparer.Compare(list[j], list[j + 1]) > 0; j--)
// {
//     (list[j], list[j + 1]) = (list[j + 1], list[j]);
// }