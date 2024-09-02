using DSA.Core.DataStructures.UnionFinds;

namespace DSA.UnitTests.DataStructures.UnionFinds;

public class QuickUnionUfTests
{
    [Fact]
    public void Test()
    {
        var quickUnion = new QuickUnionUf(10);
        
        quickUnion.Union(4, 3);
        quickUnion.Union(3, 8);
        quickUnion.Union(6, 5);
        quickUnion.Union(9, 4);
        quickUnion.Union(2, 1);
        
        Assert.True(quickUnion.Connected(8, 9));
        Assert.False(quickUnion.Connected(5, 4));
        
        quickUnion.Union(5, 0);
        quickUnion.Union(7, 2);
        quickUnion.Union(6, 1);
        quickUnion.Union(7, 3);
    }
}