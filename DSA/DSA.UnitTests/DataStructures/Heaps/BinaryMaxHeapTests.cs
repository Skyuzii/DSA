using DSA.Core.DataStructures.Heaps;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.DataStructures.Heaps;

public class BinaryMaxHeapTests
{
    [Fact]
    public void AddingElementsAndCheckingIfExtractedInSortedOrder()
    {
        var heap = new BinaryMaxHeap<int>();

        int minHeapElement = -50000;
        int maxHeapElement = 50000;
        
        var list = Enumerable.Range(minHeapElement, maxHeapElement - minHeapElement).Shuffle().ToList();

        foreach (var item in list)
        {
            heap.Push(item);
        }

        if (heap.Count != list.Count) Assert.Fail();

        int removedElements = 0;
        var max = heap.Peek();
        while (!heap.IsEmpty)
        {
            if (max < heap.Peek()) Assert.Fail();

            max = heap.Pop();
            removedElements++;
        }

        Assert.True(heap.IsEmpty);
        Assert.Equal(0, heap.Count);
        Assert.Equal(list.Count, removedElements);
    }
}