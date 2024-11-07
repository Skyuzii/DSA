using System.Collections;

namespace DSA.Core.DataStructures.Trees;

public class RedBlackTree<TKey, TValue> : IEnumerable<(TKey, TValue)> where TKey : IComparable<TKey>
{
    private Node? _root;
    private readonly IComparer<TKey> _comparer;

    public RedBlackTree()
    {
        _comparer = Comparer<TKey>.Default;
    }

    public TValue Get(TKey key)
    {
        if (TryGetValue(key, out var value))
        {
            return value!;
        }

        throw new InvalidOperationException("Not found");
    }

    public bool TryGetValue(TKey key, out TValue? value)
    {
        var node = _root;

        while (node is not null)
        {
            var cmp = _comparer.Compare(key, node.Key);

            if (cmp < 0)
            {
                node = node.Left;
            }
            else if (cmp > 0)
            {
                node = node.Right;
            }
            else
            {
                value = node.Value;
                return true;
            }
        }

        value = default;
        return false;
    }

    public void Insert(TKey key, TValue value)
    {
        _root = InsertInternal(key, value, _root);
    }

    private Node? InsertInternal(TKey key, TValue value, Node? node)
    {
        if (node is null)
        {
            return new Node(key, value);
        }

        var cmp = _comparer.Compare(key, node.Key);

        if (cmp < 0)
        {
            node.Left = InsertInternal(key, value, node.Left);
        }
        else if (cmp > 0)
        {
            node.Right = InsertInternal(key, value, node.Right);
        }
        else
        {
            node.Value = value;
        }

        if (!IsRed(node.Left) && IsRed(node.Right))
        {
            node = RotateLeft(node);
        }
        else if (IsRed(node.Left) && IsRed(node.Left?.Left))
        {
            node = RotateRight(node);
        }
        else if (IsRed(node.Left) && IsRed(node.Right))
        {
            FlipColors(node);
        }

        return node;
    }

    private bool IsRed(Node? node)
    {
        if (node is null)
        {
            return false;
        }

        return node.IsRed;
    }

    private Node RotateLeft(Node node)
    {
        var tmp = node.Right;
        node.Right = tmp.Left;
        tmp.Left = node;
        tmp.IsRed = node.IsRed;
        node.IsRed = true;
        
        return tmp;
    }

    private Node RotateRight(Node node)
    {
        var tmp = node.Left;
        node.Left = tmp.Right;
        tmp.Right = node;
        tmp.IsRed = node.IsRed;
        node.IsRed = true;

        return tmp;
    }

    private void FlipColors(Node node)
    {
        node.IsRed = true;
        node.Left.IsRed = false;
        node.Right.IsRed = false;
    }

    internal class Node
    {
        public TKey Key { get; set; }
        
        public TValue Value { get; set; }
        
        public Node? Left { get; set; }
        
        public Node? Right { get; set; }
        
        public bool IsRed { get; set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            IsRed = true;
        }
    }

    private IEnumerable<(TKey, TValue)> InOrderInternal(Node? node)
    {
        if (node is null)
        {
            yield break;
        }

        foreach (var item in InOrderInternal(node.Left))
        {
            yield return item;
        }

        yield return (node.Key, node.Value);
        
        foreach (var item in InOrderInternal(node.Right))
        {
            yield return item;
        }
    }

    public IEnumerator<(TKey, TValue)> GetEnumerator()
    {
        return InOrderInternal(_root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}