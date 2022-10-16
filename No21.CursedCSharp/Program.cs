using System.Numerics;


// int 순환
foreach (var n in 10)
{
    Console.WriteLine(n);
}

Console.WriteLine();

// double 순환
foreach (var n in 3d)
{
    Console.WriteLine(n.GetType().Name);
    Console.WriteLine(n);
}

Console.WriteLine();

foreach (var n in (1..10).Range(2))
{
    Console.WriteLine(n);
}

Console.WriteLine();

foreach (var n in 1d.To(10d, 2d))
{
    Console.WriteLine(n.GetType().Name);
    Console.WriteLine(n);
}



static class EnumerableExtensions
{
    public static IEnumerator<TValue> GetEnumerator<TValue>(this TValue value)
        where TValue : INumber<TValue>
    {
        for (TValue i = TValue.Zero; i < value; i++)
            yield return i;
    }

    public static IEnumerable<int> Range(this Range @this, int step = 1)
    {
        for (var i = @this.Start.Value; i < @this.End.Value; i += step)
            yield return i;
    }

    public static IEnumerable<TValue> To<TValue>(this TValue from, TValue to, TValue step)
        where TValue : INumber<TValue>
    {
        for (TValue i = from; i < to; i += step)
            yield return i;
    }
}
