using DSA.Core.DataStructures.Stacks;

namespace DSA.UnitTests.DataStructures.Stacks;

public class ArrayStackTests
{
    [Fact]
    public void PushingItemsOneByOne()
    {
        var stack = new ArrayStack<int>();

        var itemsCount = 10;

        for (int i = 0; i < itemsCount; i++)
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

        Assert.True(stack.Count == itemsCount && stack.Count == trueCount);
    }
}