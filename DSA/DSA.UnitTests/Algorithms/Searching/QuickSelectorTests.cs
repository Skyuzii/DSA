using DSA.Core.Algorithms.Searching;
using DSA.UnitTests.Extensions;

namespace DSA.UnitTests.Algorithms.Searching;

public class QuickSelectorTests
{
    [Fact]
    public void QuickSelectSmallestNotInPlace()
    {
        int itemCount = 10000;
        int numberOfSmallestChecks = 100;
        
        var list = Enumerable.Range(1, itemCount).Shuffle().ToList();

        // first Nth smallest check
        for (int nthSmallest = 1; nthSmallest <= numberOfSmallestChecks; nthSmallest++)
        {
            if (list.QuickSelectSmallest(nthSmallest) != nthSmallest) Assert.Fail();
        }

        // random smallest check
        for (int i = 0; i < numberOfSmallestChecks; i++)
        {
            int random = Random.Shared.Next(1, itemCount + 1);

            if (list.QuickSelectSmallest(random) != random) Assert.Fail();
        }
    }
}