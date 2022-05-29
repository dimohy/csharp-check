#pragma warning disable CS8321 // 로컬 함수가 선언되었지만 사용되지 않음

using System.Reflection;
using System.Runtime.CompilerServices;

// 문자열 보간에서 개행 허용
//Console.WriteLine(nameof(Test_CS11_NewlinesInInterpolations));
//Test_CS11_NewlinesInInterpolations();

// 목록 패턴 매칭
//Console.WriteLine(nameof(Test_CS11_ListPattern));
//Test_CS11_ListPattern();

// 인자 널 체크 (!!)
//Console.WriteLine(nameof(Test_CS11_ParameterNullChecking));
//Test_CS11_ParameterNullChecking();

// 원시 문자열 리터럴
//Console.WriteLine(nameof(Test_CS11_RawStringLiterals));
//Test_CS11_RawStringLiterals();

//Console.WriteLine(nameof(Test_CS11_GenericAttribute));
//Test_CS11_GenericAttribute();

// ReadOnlySpan<char>에 대한 switch 패턴 매칭

//void Test_CS11_ReadOnlySpanWithSwitch()
//{
//    var str = "Top";
//    var span = str.AsSpan();
//    switch (span)
//    {
//        case "Left":
//            break;
//    }
//}

//Test_CS11_UnsignedRightShift();

//Test_CS11_UTF8_Literals();

Test_CS11_SwitchingReadOnlySpan();

void Test_CS11_SwitchingReadOnlySpan()
{
    ReadOnlySpan<char> span = "Test";

    switch (span)
    {
        case "Test":
            Console.WriteLine("Hit!");
            break;
        default:
            Console.WriteLine("No hit");
            break;
    }
}

void Test_CS11_UnsignedRightShift()
{
    short a = -1;
    var b = a >>> 1;
    var c = a >> 1;
    Console.WriteLine(b);
    Console.WriteLine(c);
}

void Test_CS11_UTF8_Literals()
{
    var s1 = "테스트"u8;

    byte[] s2 = "테스트";

    Span<byte> s3 = "테스트";

    ReadOnlySpan<byte> s4 = "테스트";

    Print(s1);
    Print(s2);
    Print(s3.ToArray());
    Print(s4.ToArray());

    void Print(byte[] data)
    {
        var output = BitConverter.ToString(data);
        Console.WriteLine(output);
    }
}

//short a = 32767;
//a++;
//var result = (ushort)(a << 1);
//Console.WriteLine(Convert.ToString(a, 2));
//Console.WriteLine(Convert.ToString(result, 2));

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

void Test_CS11_RawStringLiterals()
{
    var s1 = """
a
b
c
""";
    Console.WriteLine(s1);
    Console.WriteLine();

    var s2 = """
             a
             b
             c
             """;

    Console.WriteLine(s2);
    Console.WriteLine();

    var i = 1;
    var s3 = $"""
             {i++}
             {i++}
             {i++}
             """;
    Console.WriteLine(s3);

    var s4 = $"""
            (
                {i++}
                {i++}
                {i++}
            )
            """;
    Console.WriteLine(s4);

    // 컴파일 오류
    //var s5 = $"""
    //  {{
    //      why?
    //  }}
    //  """;
    //Console.WriteLine(s5);

    var s6 =
$@"
{{
    {1} + {2} = {1 + 2}
}}
";
    Console.WriteLine(s6);
}

[Generic<string>("test")]
[Generic<int>(25)]
[TestGeneric<TestInfo>()]
void Test_CS11_GenericAttribute()
{
    var attributesDataGroup = typeof(Program).GetRuntimeMethods().Select(x => x.GetCustomAttributesData());

    foreach (var attributesData in attributesDataGroup)
    {
        foreach (var attributeData in attributesData)
            if (attributeData.AttributeType.IsGenericType is true && attributeData.AttributeType.GetGenericTypeDefinition() == typeof(GenericAttribute<>))
                Console.WriteLine(attributeData);
    }
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class GenericAttribute<T> : Attribute
{
    public T Value { get; }

    public GenericAttribute(T value)
    {
        Value = value;
    }
}

[AttributeUsage(AttributeTargets.All)]
class TestGenericAttribute<T> : Attribute
    where T : new()
{
    public T Value { get; }

    public TestGenericAttribute()
    {
        Value = new T();
    }
}

class TestInfo
{

}

struct S
{
    public int X, Y;
}
