using No2.CS11_Check;

using System.Runtime.CompilerServices;

Console.WriteLine("!");


//var s = new FileLocalType();

// ---

var user = new User
{
    Name = "dimohy",
    Age = 45
};

// ---

var emptyValue = GetEmptyValue(new NumValue(100));

// ---

int n = -2020987651; // 0b10000111100010100010110011111101

Console.WriteLine($"[n] \t\t {Convert.ToString(n, 2).PadLeft(32, '0')}");
Console.WriteLine($"[n] >>> 4 ==> \t {Convert.ToString(n >>> 4, 2).PadLeft(32, '0')}");
Console.WriteLine($"[n] >> 4 ==> \t {Convert.ToString(n >> 4, 2).PadLeft(32, '0')}");

// ---

ReadOnlySpan<byte> utf8Text = "디모이"u8; // 또는
// var utf8Text = "디모이"u8;

// ---

ReadOnlySpan<char> text = "디모이";

switch (text)
{
    case "디모이":
        break;
    default:
        break;
}

// ---

int[] arr = { 1, 2, 3, 4, 5, 6 };

var result = arr switch
{
    //[1, .., 6] => 1,
    [1, .., 5, _] => 2,
    _ => 0
};
Console.WriteLine(result);

// ---

var num = 1;
var rawText = $$""""
    {
    Line 1, value {{num}}
    Line 2, value {{num + 1}}
    Line 3, value {{num + 2}}
    }
    """Text"""
    """";

Console.WriteLine(rawText);

// ---

Assert(1 == 1);
Assert("A" == "B");


void Assert(bool condition, [CallerArgumentExpression(nameof(condition))] string? message = default)
{
    Console.WriteLine(nameof(condition));
    Console.WriteLine(message);
}

// ---


T GetEmptyValue<T>(T value) where T : IValue<T>
{
    return T.Empty;
}

// ---

class ValueAttribute<TValue> : Attribute
    where TValue : struct
{
    public TValue V { get; set; }
}

[Value<int>(V = 10)]
class TestClass
{

}

// ---
public struct S
{
    public int x, y;
    public S()
    {
    }
}

// ---

ref struct Vector
{
    public ref int X;
}

// ---

public class User
{
    public required string Name { get; init; }
    public required int Age { get; init; }
}

// ---

public interface IValue<T>
{
    static abstract T Empty { get; }
}

public class NumValue : IValue<NumValue>
{
    public static NumValue Empty { get; } = new(0);

    private int _value;

    public NumValue(int value) => _value = value;
}
