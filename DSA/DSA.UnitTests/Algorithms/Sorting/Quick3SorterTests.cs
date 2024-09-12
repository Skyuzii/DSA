using DSA.Core.Algorithms.Sorting;

namespace DSA.UnitTests.Algorithms.Sorting;

public class Quick3SorterTests
{
    [Fact]
    public void SortingInAscendingOrderAndCheckingIfSorted()
    {
        var list = new List<int>();

        int minElement = -50000;
        int maxElement = 50000;

        int addedElements = 0;

        //Adding every seventh number, then every fifth number,
        //every third and at last all numbers
        //NOTE: some items are added more than once
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

        list.Quick3Sort();

        var last = int.MinValue;
        foreach (var item in list)
        {
            if (last > item) Assert.Fail();

            last = item;
        }
    }
}