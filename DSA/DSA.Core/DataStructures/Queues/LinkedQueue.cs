using System.Collections;

namespace DSA.Core.DataStructures.Queues;

public class LinkedQueue<T> : IEnumerable<T>
{
    private Node? _head;
    private Node? _tail;
    
    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        Count++;

        if (_tail is null)
        {
            _head = new Node(item, null);
            _tail = _head;
        }
        else
        {
            _tail.Next = new Node(item, null);
            _tail = _tail.Next;   
        }
    }

    public T Dequeue()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var item = _head;

        _head = _head.Next;
        Count--;

        if (_head is null)
        {
            _tail = null;
        }

        return item.Data;
    }

    public T Peek()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _head.Data;
    }

    public void Clear()
    {
        Count = 0;
        _head = null;
        _tail = null;
    }

    internal class Node
    {
        public T Data { get; set; }
        
        public Node? Next { get; set; }
        
        public Node(T data, Node? next)
        {
            Data = data;
            Next = next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = _head;

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