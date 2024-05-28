namespace NetDaemon.Extensions;

using System.Linq;

public static class IEnumerableExtensions
{

    static readonly Random random = new Random();

    public static T? Random<T>(this IEnumerable<T> enumerable)
    {
        var count = enumerable.Count();
        if (count == 0)
            return default(T);
        var index = random.Next(count);
        return enumerable.Skip(index).First();

    }

    public static double? NullableAverage<T>(this IEnumerable<T> source, Func<T, double> selector)
    {
        return source.Any() ? source.Average<T>(selector) : null;
    }

    public static int? NullableMin<T>(this IEnumerable<T> source, Func<T, int> selector)
    {
        return source.Any() ? source.Min<T>(selector) : null;
    }

    public static int? NullableMax<T>(this IEnumerable<T> source, Func<T, int> selector)
    {
        return source.Any() ? source.Max<T>(selector) : null;
    }
}



