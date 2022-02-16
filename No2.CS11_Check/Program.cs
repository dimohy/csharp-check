// 문자열 보간에서 개행 허용
using System.Runtime.CompilerServices;

Console.WriteLine(nameof(Test_CS11_NewlinesInInterpolations));
Test_CS11_NewlinesInInterpolations();

// 목록 패턴 매칭
Test_CS11_ListPattern();

// 인자 널 체크 (!!)
Test_CS11_ParameterNullChecking();


void Test_CS11_NewlinesInInterpolations()
{
    var result = $"{
        1 +
        2 +
        3 +
        4 +
        5 +
        6 +
        7 +
        8 +
        9 +
        10}";

    Console.WriteLine(result);
}

void Test_CS11_ListPattern()
{
    var list = new[] { 1, 2, 3, 4, 5 };
    var list2 = new[] { 1, 2, 3, 7, 5 };

    Print(list is [1, 2, 3, 4, 5]);
    Print(list is [1, .., 5]);
    Print(list is [1, .., 4]);
    Print(list is [1, .., var x, 5] && x is 4);

    Print(list2 is [1, 2, 3, 4, 5]);
    Print(list2 is [1, .., 5]);
    Print(list2 is [1, .., var y, 5] && y is 7);
}

void Test_CS11_ParameterNullChecking()
{
    Method("a", "b", "c");
    Method(null!, "b", "c");

    void Method(string a!!, string b!!, string c!!)
    {
        Console.WriteLine("정상동작");
    }
}

void Print(object? value, [CallerArgumentExpression("value")] string? argumentExpression = null)
{
    System.Console.WriteLine($"{argumentExpression}: {value}");
}
