using DSA.Core.DataStructures.Heaps;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.DataStructures.Heaps;

public class BinaryMinHeapTests
{
    [Fact]
    public void AddingElementsAndCheckingIfExtractedInSortedOrder()
    {
        var heap = new BinaryMinHeap<int>();

        int minHeapElement = -50000;
        int maxHeapElement = 50000;
        
        var list = Enumerable.Range(minHeapElement, maxHeapElement - minHeapElement).Shuffle().ToList();

        if (heap.Count != list.Count) Assert.Fail();

        int removedElements = 0;
        var min = heap.Peek();
        while (!heap.IsEmpty)
        {
            if (min > heap.Peek()) Assert.Fail();

            min = heap.Pop();
            removedElements++;
        }

        Assert.True(heap.IsEmpty);
        Assert.Equal(0, heap.Count);
        Assert.Equal(list.Count, removedElements);
    }
}