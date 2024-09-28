using DSA.Core.Algorithms.Sorting;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Sorting;

public class SelectionSorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        int minElement = -3000;
        int maxElement = 3000;
        
        var list = Enumerable.Range(minElement, maxElement - minElement).Shuffle().ToList();

        list.SelectionSort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item)
            {
                Assert.Fail();
            }

            last = item;
        }
    }

    [Fact]
    public void SortingInDescendingOrderAndCheckingIfSorted()
    {
        var list = new List<int>();

        int minElement = -3000;
        int maxElement = 3000;

        int addedElements = 0;
        
        for (int i = 7; i > 0; i -= 2)
        {
            int el = maxElement;
            while (el >= minElement)
            {
                list.Add(el);
                addedElements++;
                el -= i;
            }
        }

        list.SelectionSortDesc();

        var last = int.MaxValue;
        foreach (var item in list)
        {
            if (last < item) Assert.Fail();

            last = item;
        }
    }
}