using DSA.Core.DataStructures.Heaps;

namespace DSA.UnitTests.DataStructures.Heaps;

public class BinaryMaxHeapTests
{
    [Fact]
    public void AddingElementsAndCheckingIfExtractedInSortedOrder()
    {
        var heap = new BinaryMaxHeap<int>();

        int maxHeapElement = 50000;
        int minHeapElement = -50000;

        int addedElements = 0;

        for (int i = 7; i > 0; i -= 2)
        {
            int el = minHeapElement;
            while (el <= maxHeapElement)
            {
                heap.Push(el);
                addedElements++;
                el += i;
            }
        }

        if (heap.Count != addedElements) Assert.Fail();

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
        Assert.Equal(addedElements, removedElements);
    }
}