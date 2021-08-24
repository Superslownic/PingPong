using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

public static class EnumerableExtensions
{
    public static T Any<T>(this IEnumerable<T> enumerable)
    {
        var random = new Random();
        return enumerable.ElementAt(random.Next(enumerable.Count()));
    }
}
