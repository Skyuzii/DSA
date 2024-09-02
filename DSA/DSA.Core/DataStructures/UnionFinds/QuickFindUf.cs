namespace DSA.Core.DataStructures.UnionFinds;

public class QuickFindUf
{
    private int[] _array;

    public QuickFindUf(int size)
    {
        _array = Enumerable.Range(0, size).ToArray();
    }

    public void Union(int p, int q)
    {
        if (p == q)
        {
            return;
        }

        var oldValue = _array[p];
        var newValue = _array[q];

        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] == oldValue)
            {
                _array[i] = newValue;
            }
        }
    }

    public bool Connected(int p, int q)
    {
        return _array[p] == _array[q];
    }
}