using DSA.Core.DataStructures.Stacks;

namespace DSA.UnitTests.DataStructures.Stacks;

public class LinkedStackTests
{
    [Fact]
    public void PushingItemsOneByOne()
    {
        var stack = new LinkedStack<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        int trueCount = 0;
        int lastItem = int.MaxValue;

        foreach (var item in stack)
        {
            if (lastItem < item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(stack.Count == itemCount
                      && stack.Count == trueCount);
    }

    [Fact]
    public void PoppingAllExceptOne()
    {
        var stack = new LinkedStack<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        int lastItem = int.MaxValue;
        for (int i = 0; i < itemCount - 1; i++)
        {
            if (lastItem < stack.Pop()) Assert.Fail();
        }

        int trueCount = 0;


        foreach (var item in stack)
        {
            trueCount++;
        }

        Assert.True(stack.Count == 1
                      && trueCount == 1);
    }

    [Fact]
    public void PoppingAllItemsAndPushingAgain()
    {
        var stack = new LinkedStack<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        int lastItem = int.MaxValue;
        for (int i = 0; i < itemCount; i++)
        {
            if (lastItem < stack.Pop()) Assert.Fail();
        }

        bool countWasZero = stack.Count == 0;

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        int trueCount = 0;
        lastItem = int.MaxValue;

        foreach (var item in stack)
        {
            if (lastItem < item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(stack.Count == itemCount
                      && stack.Count == trueCount
                      && countWasZero);
    }

    [Fact]
    public void CheckIfContainedBeforeAndAfterPopping()
    {
        var stack = new LinkedStack<int>();

        int itemCount = 10000;

        for (int i = 0; i < itemCount; i++)
        {
            if (stack.Contains(i)) Assert.Fail();
            stack.Push(i);
            if (!stack.Contains(i)) Assert.Fail();
        }

        int lastItem = int.MaxValue;
        for (int i = itemCount - 1; i >= 0; i--)
        {
            var top = stack.Peek();
            if (!stack.Contains(i)) Assert.Fail();
            var popped = stack.Pop();
            if (popped != top) Assert.Fail();
            if (lastItem < popped) Assert.Fail();
            if (stack.Contains(i)) Assert.Fail();
            lastItem = top;
        }

        Assert.True(stack.Count == 0);
    }

    [Fact]
    public void PushingAfterClearingCollection()
    {
        var stack = new LinkedStack<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        stack.Clear();

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        int trueCount = 0;
        int lastItem = int.MaxValue;
        foreach (var item in stack)
        {
            if (lastItem < item) Assert.Fail();
            lastItem = item;
            trueCount++;
        }

        Assert.True(stack.Count == itemCount
                      && stack.Count == trueCount);
    }

    [Fact]
    public void PushingItemsAndCheckingIfIteratedInReversedOrder()
    {
        var stack = new LinkedStack<int>();

        int itemCount = 500000;

        for (int i = 0; i < itemCount; i++)
        {
            stack.Push(i);
        }

        int trueCount = 0;
        int itemNum = itemCount - 1;
        foreach (var item in stack)
        {
            if (itemNum-- != item) Assert.Fail();
            trueCount++;
        }

        Assert.True(stack.Count == itemCount
                      && stack.Count == trueCount);
    }
}