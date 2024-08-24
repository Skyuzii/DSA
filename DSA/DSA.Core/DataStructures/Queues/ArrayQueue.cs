using System.Collections;

namespace DSA.Core.DataStructures.Queues;

public class ArrayQueue<T> : IEnumerable<T>
{
    private T[] _array;

    private int _head;
    private int _tail;

    public int Count => _tail - _head ;

    public ArrayQueue() : this(capacity: 4)
    {
    } 
    
    public ArrayQueue(int capacity)
    {
        _array = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if ((uint)_tail >= (uint)_array.Length)
        {
            Increase();
        }

        _array[_tail++] = item;
    }

    public T Peek()
    {
        if (_head >= _tail)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _array[_head];
    }

    public T Dequeue()
    {
        if (_head >= _tail)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var item = _array[_head];

        _head++;

        if (_head == _tail)
        {
            _head = 0;
            _tail = 0;
        }
        else if (Count << 1 < _array.Length)
        {
            Decrease();
        }

        return item;
    }

    public void Clear()
    {
        _array = new T[4];
        _head = 0;
        _tail = 0;
    }

    private void Increase()
    {
        var newSize = _array.Length == 0 ? 4 : _array.Length << 1;

        Array.Resize(ref _array, newSize);
    }

    private void Decrease()
    {
        var newSize = _array.Length >> 1;

        var newArray = new T[newSize];

        var cnt = _tail - _head;
        
        for (int i = 0; i < cnt; i++)
        {
            newArray[i] = _array[_head++];
        }

        _array = newArray;
        _head = 0;
        _tail = cnt;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _head; i < _tail; i++)
        {
            yield return _array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}