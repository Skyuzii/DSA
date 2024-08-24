using System.Collections;

namespace DSA.Core.DataStructures.Stacks;

public class LinkedStack<T> : IEnumerable<T>
{
    private Node? _head;
    
    public int Count { get; private set; }

    public LinkedStack()
    {
        _head = null;
        Count = 0;
    }

    public void Push(T item)
    {
        _head = new Node(item, _head);
        Count++;
    }

    public T Pop()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        var item = _head.Data;

        _head = _head.Next;
        Count--;

        return item;
    }

    public T Peek()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _head.Data;
    }

    public void Clear()
    {
        _head = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        Node? currentNode = _head;

        while (currentNode is not null)
        {
            if (object.Equals(currentNode.Data, item))
            {
                return true;
            }

            currentNode = currentNode.Next;
        }

        return false;
    }
    
    internal class Node
    {
        public T Data { get; set; }
        
        public Node Next { get; set; }

        public Node(T data, Node next)
        {
            Data = data;
            Next = next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? currentNode = _head;

        while (currentNode is not null)
        {
            yield return currentNode.Data;

            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}