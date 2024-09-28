using DSA.Core.Algorithms.Sorting;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Sorting;

public class Quick3SorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        int minElement = -50000;
        int maxElement = 50000;
        
        var list = Enumerable.Range(minElement, maxElement - minElement).Shuffle().ToList();

        list.Quick3Sort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}