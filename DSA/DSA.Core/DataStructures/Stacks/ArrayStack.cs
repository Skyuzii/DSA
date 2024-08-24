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

    public T Pop()
    {
        var index = _tail - 1;

        if ((uint)index >= (uint)_array.Length)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        if (index * 3 <= _array.Length)
        {
            Resize(increase: false);
        }

        _tail = index;

        return _array[index];
    }

    private void Resize(bool increase)
    {
        var newSize = increase ? _tail << 1 : _tail >> 1;

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