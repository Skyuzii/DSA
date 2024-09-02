namespace DSA.Core.DataStructures.UnionFinds;

public class WeightedQuickUnionUf
{
    private int[] _array;
    private int[] _counts;

    public WeightedQuickUnionUf(int size)
    {
        _array = new int[size];
        _counts = new int[size];

        for (int i = 0; i < size; i++)
        {
            _array[i] = i;
            _counts[i] = 1;
        }
    }

    private int GetRoot(int index)
    {
        while (index != _array[index])
        {
            _array[index] = _array[_array[index]];
            index = _array[index];
        }

        return index;
    }

    public void Union(int p, int q)
    {
        var pRoot = GetRoot(p);
        var qRoot = GetRoot(q);

        if (pRoot == qRoot)
        {
            return;
        }

        if (_counts[pRoot] < _counts[qRoot])
        {
            _array[pRoot] = qRoot;
            _counts[qRoot] += _counts[pRoot];
        }
        else
        {
            _array[qRoot] = pRoot;
            _counts[pRoot] += _counts[qRoot];
        }
    }

    public bool Connected(int p, int q)
    {
        return GetRoot(p) == GetRoot(q);
    }
}