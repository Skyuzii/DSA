namespace DSA.UnitTests.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> data)
    {
        return data.OrderBy(x => Random.Shared.Next());
    }
}