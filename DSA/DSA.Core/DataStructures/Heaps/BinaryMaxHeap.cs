namespace DSA.Core.DataStructures.Heaps;

public class BinaryMaxHeap<T> where T : IComparable<T>
{
    private readonly List<T> _data;
    private readonly IComparer<T> _comparer;
    
    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public BinaryMaxHeap() : this(0)
    {
    }
    
    public BinaryMaxHeap(int capacity)
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
        _data.RemoveAt(_data.Count - 1);
        NodeHeapifyDown();
        Count--;

        return item;
    }

    private void NodeHeapifyUp(int nodeIndex)
    {
        while (nodeIndex > 0)
        {
            var parentIndex = GetParentIndex(nodeIndex);

            if (_comparer.Compare(_data[parentIndex], _data[nodeIndex]) > 0)
            {
                break;
            }

            (_data[parentIndex], _data[nodeIndex]) = (_data[nodeIndex], _data[parentIndex]);
            nodeIndex = parentIndex;
        }
    }

    private void NodeHeapifyDown()
    {
        var parentIndex = 0;
        
        while (true)
        {
            var leftNodeIndex = GetLeftNodeIndex(parentIndex);
            var rightNodeIndex = GetRightNodeIndex(parentIndex);

            if (leftNodeIndex >= _data.Count)
            {
                break;
            }

            var biggestNodeIndex = parentIndex;
            
            if (leftNodeIndex < _data.Count && _comparer.Compare(_data[biggestNodeIndex], _data[leftNodeIndex]) < 0)
            {
                biggestNodeIndex = leftNodeIndex;
            }
            
            if (rightNodeIndex < _data.Count && _comparer.Compare(_data[biggestNodeIndex], _data[rightNodeIndex]) < 0)
            {
                biggestNodeIndex = rightNodeIndex;
            }

            if (parentIndex == biggestNodeIndex)
            {
                break;
            }

            (_data[parentIndex], _data[biggestNodeIndex]) = (_data[biggestNodeIndex], _data[parentIndex]);
            parentIndex = biggestNodeIndex;
        }
    }

    private int GetParentIndex(int nodeIndex)
    {
        return (nodeIndex - 1) / 2;
    }

    private int GetLeftNodeIndex(int parentIndex)
    {
        return parentIndex * 2 + 1;
    }
    
    private int GetRightNodeIndex(int parentIndex)
    {
        return parentIndex * 2 + 2;
    }
}