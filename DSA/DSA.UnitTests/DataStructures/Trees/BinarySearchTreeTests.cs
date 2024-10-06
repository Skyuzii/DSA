using DSA.Core.DataStructures.Trees;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.DataStructures.Trees;

public class BinarySearchTreeTests
{
    [Fact]
    public void SortedElementsAfterAdding()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

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
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

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
    
    [Fact]
    public void GetCorrectedMinElement()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int elementsCount = 10000;
        int minElement = 10;

        var data = Enumerable.Range(minElement, elementsCount).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        var minElementByTree = tree.GetMin();

        Assert.Equal(minElement, minElementByTree!.Value.Item1);
    }
    
    [Fact]
    public void GetCorrectedMaxElement()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        var maxElementByTree = tree.GetMax();

        Assert.Equal(maxElement, maxElementByTree!.Value.Item1);
    }
    
    [Fact]
    public void GetCorrectedFloorElement()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        data.Remove(10);
        
        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        var floorElement = tree.Floor(10);

        Assert.Equal(9, floorElement);
    }
    
    [Fact]
    public void GetCorrectedCeilingElement()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        data.Remove(10);

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        var ceilingElement = tree.Ceiling(10);

        Assert.Equal(expected: 11, ceilingElement);
    }
    
    [Fact]
    public void DeleteMin()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        tree.DeleteMin();

        Assert.DoesNotContain(tree, x => x.Item1 == minElement);
    }
    
    [Fact]
    public void DeleteMax()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        tree.DeleteMax();

        Assert.DoesNotContain(tree, x => x.Item1 == maxElement);
    }
    
    [Fact]
    public void Delete()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        tree.Delete(data[50]);

        Assert.Equal(maxElement, tree.Count);
        Assert.DoesNotContain(tree, x => x.Item1 == data[50]);
    }
    
    [Fact]
    public void DeleteAllExceptOne()
    {
        BinarySearchTree<int, int> tree = new BinarySearchTree<int, int>();

        int minElement = 0;
        int maxElement = 100;

        var data = Enumerable.Range(minElement, maxElement + 1).Shuffle().ToList();

        foreach (var item in data)
        {
            tree.Insert(item, item);
        }

        for (int i = 0; i < maxElement; i++)
        {
            tree.Delete(data[i]);
        }

        Assert.Equal(1, tree.Count);
    }
}