var items = Enumerable
    .Range(1, 10)
    .ToList();

var indexes = new[] { 20, -1, -20, -15, 5, -23 };

var results = indexes
    .Select(index => (index, items.IndexAtLooped(index)))
    .ToList();

foreach (var (index, result) in results)
    Console.WriteLine($"{index,3}: {result}");


public static class EnumerableExtensions
{
    public static T? IndexAtLooped<T>(this IList<T>? collection, int index)
    {
        if (collection is null || collection.Any() is false)
            return default;

        var total = collection.Count;
        index %= total;
        if (index < 0)
            index += total;

        return collection[index];
    }
}

