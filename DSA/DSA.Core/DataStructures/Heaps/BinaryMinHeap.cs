namespace DSA.Core.DataStructures.Heaps;

public class BinaryMinHeap<T> where T : IComparable<T>
{
    private readonly List<T> _data;
    private readonly IComparer<T> _comparer;
    
    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public BinaryMinHeap() : this(0)
    {
    }
    
    public BinaryMinHeap(int capacity)
    {
        _data = new List<T>(capacity);
        _comparer = Comparer<T>.Default;
    }

    public void Push(T item)
    {
        _data.Add(item);
        NodeHeapifyUp(_data.Count - 1);
        Count++;
    }

    public T Peek()
    {
        return _data[0];
    }

    public T Pop()
    {
        var item = _data[0];
        _data[0] = _data[^1];
        NodeHeapifyDown();
        Count--;
        
        return item;
    }

    private void NodeHeapifyUp(int nodeIndex)
    {
        while (nodeIndex > 0)
        {
            var parentNodeIndex = GetParentNodeIndex(nodeIndex);

            if (_comparer.Compare(_data[parentNodeIndex], _data[nodeIndex]) > 0)
            {
                return;
            }

            (_data[parentNodeIndex], _data[nodeIndex]) = (_data[nodeIndex], _data[parentNodeIndex]);
            nodeIndex = parentNodeIndex;
        }
    }

    private void NodeHeapifyDown()
    {
        var parentNodeIndex = 0;

        while (true)
        {
            var leftNodeIndex = GetLeftNodeIndex(parentNodeIndex);
            var rightNodeIndex = GetRightNodeIndex(parentNodeIndex);

            if (leftNodeIndex >= _data.Count)
            {
                return;
            }

            var smallestNodeIndex = parentNodeIndex;

            if (_comparer.Compare(_data[smallestNodeIndex], _data[leftNodeIndex]) > 0)
            {
                smallestNodeIndex = leftNodeIndex;
            }

            if (rightNodeIndex < _data.Count && _comparer.Compare(_data[smallestNodeIndex], _data[rightNodeIndex]) > 0)
            {
                smallestNodeIndex = rightNodeIndex;
            }

            if (parentNodeIndex == smallestNodeIndex)
            {
                return;
            }

            (_data[parentNodeIndex], _data[smallestNodeIndex]) = (_data[smallestNodeIndex], _data[parentNodeIndex]);
            parentNodeIndex = smallestNodeIndex;
        }
    }

    private int GetParentNodeIndex(int nodeIndex)
    {
        return (nodeIndex - 1) / 2;
    }

    private int GetLeftNodeIndex(int parentNodeIndex)
    {
        return parentNodeIndex * 2 + 1;
    }

    private int GetRightNodeIndex(int parentNodeIndex)
    {
        return parentNodeIndex * 2 + 2;
    }
}