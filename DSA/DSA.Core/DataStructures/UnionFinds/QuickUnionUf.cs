namespace DSA.Core.DataStructures.UnionFinds;

public class QuickUnionUf
{
    private int[] _array;

    public QuickUnionUf(int size)
    {
        _array = Enumerable.Range(0, size).ToArray();
    }

    private int GetRoot(int index)
    {
        // 0, 1, 2, 8, 3, 5, 6, 7, 8, 9
        // index = 4
        // index = 3
        // index = 8
        // return index = 8
        
        while (index != _array[index])
        {
            index = _array[index];
        }

        return index;
    }

    public void Union(int p, int q)
    {
        var pRoot = GetRoot(p);
        var qRoot = GetRoot(q);

        _array[pRoot] = qRoot;
    }

    public bool Connected(int p, int q)
    {
        return GetRoot(p) == GetRoot(q);
    }
}