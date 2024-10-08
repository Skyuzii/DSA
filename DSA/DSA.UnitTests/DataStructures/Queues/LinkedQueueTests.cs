using DSA.Core.DataStructures.Queues;

namespace DSA.UnitTests.DataStructures.Queues;

public class LinkedQueueTests
{
    [Fact]
    public void EnqueuingItemsOneByOne()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int trueCount = 0;
        int lastItem = int.MinValue;

        foreach (var item in queue)
        {
            if (lastItem > item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(queue.Count == itemCount
                    && queue.Count == trueCount);
    }

    [Fact]
    public void DequeuingAllExceptOne()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int lastItem = int.MinValue;
        for (int i = 0; i < itemCount - 1; i++)
        {
            if (lastItem > queue.Dequeue()) Assert.Fail();
        }

        int trueCount = 0;


        foreach (var item in queue)
        {
            trueCount++;
        }

        Assert.True(queue.Count == 1
                    && trueCount == 1);
    }

    [Fact]
    public void DequeuingAllItemsAndEnqueuingAgain()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int lastItem = int.MinValue;
        for (int i = 0; i < itemCount; i++)
        {
            if (lastItem > queue.Dequeue()) Assert.Fail();
        }

        bool countWasZero = queue.Count == 0;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int trueCount = 0;
        lastItem = int.MinValue;

        foreach (var item in queue)
        {
            if (lastItem > item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(queue.Count == itemCount
                    && queue.Count == trueCount
                    && countWasZero);
    }

    [Fact]
    public void CheckIfContainedBeforeAndAfterDequeuing()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 10000;

        for (int i = 0; i < itemCount; i++)
        {
            if (queue.Contains(i)) Assert.Fail();
            queue.Enqueue(i);
            if (!queue.Contains(i)) Assert.Fail();
        }

        int lastItem = int.MinValue;
        for (int i = 0; i < itemCount; i++)
        {
            var first = queue.Peek();
            if (!queue.Contains(i)) Assert.Fail();
            var dequeued = queue.Dequeue();
            if (dequeued != first) Assert.Fail();
            if (lastItem > dequeued) Assert.Fail();
            if (queue.Contains(i)) Assert.Fail();
            lastItem = first;
        }

        Assert.True(queue.Count == 0);
    }

    [Fact]
    public void EnqueuingAfterClearingCollection()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        queue.Clear();

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int trueCount = 0;
        int lastItem = int.MinValue;
        foreach (var item in queue)
        {
            if (lastItem > item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(queue.Count == itemCount
                    && queue.Count == trueCount);
    }

    [Fact]
    public void EnqueuingItemsAndCheckingIfIteratedInCorrectly()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int trueCount = 0;
        int itemNum = 0;
        foreach (var item in queue)
        {
            if (itemNum++ != item) Assert.Fail();
            trueCount++;
        }

        Assert.True(queue.Count == itemCount
                      && queue.Count == trueCount);
    }

    [Fact]
    public void ConvertingQueueToArray()
    {
        var queue = new LinkedQueue<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        var array = queue.ToArray();

        int trueCount = 0;
        for (int i = 0; i < itemCount; i++)
        {
            if (array[i] != i) Assert.Fail();
            trueCount++;
        }

        Assert.True(queue.Count == itemCount
                    && queue.Count == trueCount);
    }

    [Fact]
    public void DequeuingHalfTheItemsAndEnquingTwiceAsMuch()
    {
        int itemCount = 500000;

        var queue = new LinkedQueue<int>();

        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        int lastItem = int.MinValue;
        for (int i = 0; i < itemCount >> 1; i++)
        {
            if (lastItem > queue.Dequeue()) Assert.Fail();
        }

        int maxItem = itemCount + itemCount * 2;

        for (int i = itemCount; i < maxItem; i++)
        {
            queue.Enqueue(i);
        }

        itemCount = maxItem - itemCount + itemCount / 2;

        int trueCount = 0;
        lastItem = int.MinValue;
        foreach (var item in queue)
        {
            if (lastItem > item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(queue.Count == trueCount
                    && itemCount == trueCount);
    }
}