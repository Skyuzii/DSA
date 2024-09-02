using DSA.Core.DataStructures.UnionFinds;

namespace DSA.UnitTests.DataStructures.UnionFinds;

public class WeightedQuickUnionUfTests
{
    [Fact]
    public void Test()
    {
        var weightedQuickUnion = new WeightedQuickUnionUf(10);

        weightedQuickUnion.Union(4, 3);
        weightedQuickUnion.Union(3, 8);
        weightedQuickUnion.Union(6, 5);
        weightedQuickUnion.Union(9, 4);
        weightedQuickUnion.Union(2, 1);
        weightedQuickUnion.Union(5, 0);
        weightedQuickUnion.Union(7, 2);
        weightedQuickUnion.Union(6, 1);
        weightedQuickUnion.Union(7, 3);
        
        Assert.True(weightedQuickUnion.Connected(1, 9));
        Assert.True(weightedQuickUnion.Connected(7, 4));
    }
}