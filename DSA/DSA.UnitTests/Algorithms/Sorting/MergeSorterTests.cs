using DSA.Core.Algorithms.Sorting;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Sorting;

public class MergeSorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        int minElement = -10000;
        int maxElement = 10000;
        
        var list = Enumerable.Range(minElement, maxElement - minElement).Shuffle().ToList();

        list.MergeSort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}