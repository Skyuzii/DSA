using System.Collections;

namespace DSA.Core.DataStructures.Stacks;

public class ArrayStack<T> : IEnumerable<T>
{
    private int _tail;
    private T[] _array;

    public int Count => _tail;

    public ArrayStack() : this(capacity: 4)
    {
    }

    public ArrayStack(int capacity)
    {
        _array = new T[capacity];
    }

    public void Push(T item)
    {
        if ((uint)_tail >= (uint)_array.Length)
        {
            Resize(increase: true);
        }

        _array[_tail++] = item;
    }

    public T Peek()
    {
        if ((uint)_tail >= (uint)_array.Length)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _array[_tail - 1];
    }

    public T Pop()
    {
        var index = _tail - 1;

        if ((uint)index >= (uint)_array.Length)
        {
            throw new InvalidOperationException("Stack is empty");
        } 
        
        var item = _array[index];

        if (_tail * 3 <= _array.Length)
        {
            Resize(increase: false);
        }
        
        _tail = index;

        return item;
    }
    
    public void Clear()
    {
        _tail = 0;
        _array = new T[4];
    }

    private void Resize(bool increase)
    {
        var newSize = _array.Length == 0 ? 4 : increase ? _array.Length << 1 : _array.Length >> 1;
        
        Array.Resize(ref _array, newSize);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _tail - 1; i >= 0; i--)
        {
            yield return _array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}