using DSA.Core.Algorithms.Sorting;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Sorting;

public class QuickSorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        int minElement = -1000000;
        int maxElement = 1000000;
        
        var list = Enumerable.Range(minElement, maxElement - minElement).Shuffle().ToList();

        list.QuickSort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}