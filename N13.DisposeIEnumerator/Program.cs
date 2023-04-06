using System.Collections;

var de = new DisposableEnumerable();

foreach (var value in de)
{
    Console.WriteLine(value);

    if (value is 5)
        break;
}

public class DisposableEnumerable : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new DisposableEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}




public class DisposableEnumerator : IEnumerator<int>, IDisposable
{
    private int _value;

    public int Current => _value;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        Console.WriteLine("Call Dispose!");
    }

    public bool MoveNext()
    {
        _value++;
        if (_value is 10)
            return false;

        return true;
    }

    public void Reset()
    {
        _value = 0;
    }
}