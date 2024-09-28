using DSA.Core.Algorithms.Sorting;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Sorting;

public class MergeBUSorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        int minElement = -10000;
        int maxElement = 10000;
        
        var list = Enumerable.Range(minElement, maxElement - minElement).Shuffle().ToList();

        list.MergeBUSort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}