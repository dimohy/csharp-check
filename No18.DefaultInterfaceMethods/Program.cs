using System.Collections;

var e = new Enum();
Test1(e);


static void Test1<T>(IEnum<T> enums)
{
    Console.WriteLine($"Count: {enums.NewCount()}");

    foreach (var n in enums)
        Console.WriteLine(n);
}


interface IEnum<T> : IEnumerable<T>
{

    int NewCount()
    {
        var count = 0;
        foreach (var i in this)
            count++;
        return count;
    }
}

class Enum : IEnum<int>
{
    private readonly List<int> _list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//    int IEnum<int>.NewCount() => _list.Count;

    public IEnumerator<int> GetEnumerator() => _list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
}
