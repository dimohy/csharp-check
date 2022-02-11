
using System.Runtime.CompilerServices;

var i = new TestClass();

Print(i.Add(5, 4));
Print(i.Add(5, null));
Print(i.Add("A", "B"));

void Print(object? value, [CallerArgumentExpression("value")] string? argumentExpression = null)
{
    System.Console.WriteLine($"{argumentExpression}: {value}");
}

interface IAddable<T>
{
    T? Add(T? a, T? b);
}

class TestClass : IAddable<int>, IAddable<int?>, IAddable<string>
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int? Add(int? a, int? b)
    {
        if (a is null || b is null)
            return null;

        return a + b;
    }

    public string? Add(string? a, string? b)
    {
        if (a is null || b is null)
            return null;

        return a + b;
    }
}

//interface IAddable2<T>
//{
//    T Add(T a, T b);
//}

//class TestClass2 : IAddable2<string>, IAddable2<string?> // CS8645: 인터페이스 중복
//{
//    public string Add(string a, string b) // CS8767: 구현된 멤버와 일치하지 않음
//    {
//        throw new NotImplementedException();
//    }

//    public string? Add(string? a, string? b) // CS0111: 동일한 'Add' 멤버
//    {
//        throw new NotImplementedException();
//    }
//}