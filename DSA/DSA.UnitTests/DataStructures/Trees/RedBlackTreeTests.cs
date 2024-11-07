using DSA.Core.DataStructures.Trees;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.DataStructures.Trees;

public class RedBlackTreeTests
{
    [Fact]
    public void SortedElementsAfterAdding()
    {
        RedBlackTree<int, int> tree = new RedBlackTree<int, int>();

        int elementsCount = 10000;

        var data = Enumerable.Range(0, elementsCount).Shuffle();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        int last = -1;
        int count = 0;
        bool elementsAreSorted = true;

        foreach ((int key, int value) in tree)
        {
            if (last > key)
            {
                elementsAreSorted = false;
            }

            last = key;
            count++;
        }
        
        Assert.True(elementsAreSorted);
        Assert.Equal(elementsCount, count);
    }
    
    [Fact]
    public void GetElementsAfterAdding()
    {
        RedBlackTree<int, int> tree = new RedBlackTree<int, int>();

        int elementsCount = 10000;

        var data = Enumerable.Range(10, elementsCount).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        foreach (var item in data)
        {
            if (!tree.TryGetValue(item, out var value))
            {
                Assert.Fail();
            }
        }
    }
}