using System.Collections;

namespace DSA.Core.DataStructures.Trees;

public class BinarySearchTree<TKey, TValue> : IEnumerable<(TKey, TValue)> where TKey : IComparable<TKey>
{
    private Node? _root;
    private readonly IComparer<TKey> _comparer;
    
    public int Count { get; private set; }

    public BinarySearchTree()
    {
        _comparer = Comparer<TKey>.Default;
    }

    public TValue Get(TKey key)
    {
        if (TryGetValue(key, out var value))
        {
            return value!;
        }

        throw new ArgumentOutOfRangeException(nameof(key), key, null);
    }
    
    public bool TryGetValue(TKey key, out TValue? value)
    {
        value = default;
        
        var node = _root;

        while (node is not null)
        {
            var cmp = _comparer.Compare(key, node.Key);

            if (cmp == 0)
            {
                value = node.Value;

                return true;
            }

            if (cmp < 0)
            {
                node = node.Left;
            }
            else
            {
                node = node.Right;
            }
        }

        return false;
    }

    public void Insert(TKey key, TValue value)
    {
        var newNode = new Node(key, value);

        if (_root is null)
        {
            _root = newNode;
            Count++;
            return;
        }

        var node = _root;

        while (node is not null)
        {
            var cmp = _comparer.Compare(key, node.Key);

            if (cmp == 0)
            {
                node.Value = value;
                return;
            }

            if (cmp < 0)
            {
                if (node.Left is null)
                {
                    node.Left = newNode;
                    Count++;
                    return;
                }

                node = node.Left;
            }
            else
            {
                if (node.Right is null)
                {
                    node.Right = newNode;
                    Count++;
                    return;
                }

                node = node.Right;
            }
        }
    }

    public TValue? Floor(TKey key)
    {
        var node = _root;

        var floorNode = _root;
        
        while (node is not null)
        {
            var cmp = _comparer.Compare(key, node.Key);

            if (cmp == 0)
            {
                return node.Value;
            }

            if (cmp < 0)
            {
                node = node.Left;
            }
            else
            {
                floorNode = node;
                node = node.Right;
            }
        }

        return floorNode is null
            ? default
            : floorNode.Value;
    }

    public TValue? Ceiling(TKey key)
    {
        var node = _root;

        var ceilingNode = _root;

        while (node is not null)
        {
            var cmp = _comparer.Compare(key, node.Key);

            if (cmp == 0)
            {
                return node.Value;
            }

            if (cmp < 0)
            {
                ceilingNode = node;
                node = node.Left;
            }
            else
            {
                node = node.Right;
            }
        }

        return ceilingNode is null
            ? default
            : ceilingNode.Value;
    }

    public (TKey, TValue)? Min()
    {
        if (_root is null)
        {
            return null;
        }
        
        var node = _root;

        while (node.Left is not null)
        {
            node = node.Left;
        }

        return (node.Key, node.Value);
    }
    
    public (TKey, TValue)? Max()
    {
        if (_root is null)
        {
            return null;
        }
        
        var node = _root;

        while (node.Right is not null)
        {
            node = node.Right;
        }

        return (node.Key, node.Value);
    }

    private class Node
    {
        public TKey Key { get; set; }
        
        public TValue Value { get; set; }
        
        public Node? Left { get; set; }
        
        public Node? Right { get; set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
    
    private IEnumerable<(TKey, TValue)> InOrderInternal(Node? node)
    {
        if (node is not null)
        {
            if (node.Left is not null)
            {
                foreach (var item in InOrderInternal(node.Left))
                {
                    yield return item;
                }
            }

            yield return (node.Key, node.Value);

            if (node.Right is not null)
            {
                foreach (var item in InOrderInternal(node.Right))
                {
                    yield return item;
                }
            }
        }
    }

    public IEnumerator<(TKey, TValue)> GetEnumerator()
    {
        if (_root is not null)
        {
            foreach (var item in InOrderInternal(_root))
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}