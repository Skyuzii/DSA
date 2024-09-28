using DSA.Core.Algorithms.Sorting;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Sorting;

public class InsertionSorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        int minElement = -3000;
        int maxElement = 3000;
        
        var list = Enumerable.Range(minElement, maxElement - minElement).Shuffle().ToList();

        list.InsertionSort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}