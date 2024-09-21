using DSA.Core.Algorithms.Sorting;

namespace DSA.UnitTests.Algorithms.Sorting;

public class MergeSorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        var list = new List<int>();

        int minElement = -10000;
        int maxElement = 10000;

        int addedElements = 0;
        
        for (int i = 7; i > 0; i -= 2)
        {
            int el = minElement;
            while (el <= maxElement)
            {
                list.Add(el);
                addedElements++;
                el += i;
            }
        }

        list.MergeSort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}