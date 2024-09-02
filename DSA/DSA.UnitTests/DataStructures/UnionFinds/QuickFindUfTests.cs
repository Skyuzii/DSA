using DSA.Core.DataStructures.UnionFinds;

namespace DSA.UnitTests.DataStructures.UnionFinds;

public class QuickFindUfTests
{
    [Fact]
    public void Test()
    {
        var quickFind = new QuickFindUf(10);
        
        quickFind.Union(4, 3);
        quickFind.Union(3, 8);
        quickFind.Union(6, 5);
        quickFind.Union(9, 4);
        quickFind.Union(2, 1);
        
        Assert.True(quickFind.Connected(8, 9));
        Assert.False(quickFind.Connected(5, 0));
        
        quickFind.Union(5, 0);
        quickFind.Union(7, 2);
        quickFind.Union(6, 1);
        
        Assert.True(quickFind.Connected(0, 1));
        Assert.True(quickFind.Connected(1, 7));
        Assert.True(quickFind.Connected(3, 4));
        Assert.True(quickFind.Connected(8, 9));
        Assert.True(quickFind.Connected(3, 9));
    }
}