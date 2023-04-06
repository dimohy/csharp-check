// 함수의 성공/실패를 반환값을 통해 식별할 수 있는 Result 구현

Console.Write("a = ? ");
var a = int.Parse(Console.ReadLine()!);
Console.Write("b = ? ");
var b = int.Parse(Console.ReadLine()!);

var result = AddPositive(a, b);
if (result.IsError is true)
{ 
    Console.WriteLine(result.ErrorMessage);
    return;
}

Console.WriteLine(result.Value);

static Result<int> AddPositive(int a, int b)
{
    if (a < 0 || b < 0)
        return Result<int>.Error("양수만 더할 수 있습니다.");

    return Result<int>.Success(a + b);
}



readonly ref struct Result<T>
{
    public required T Value { get; init; }
    public string ErrorMessage { get; init; }
    public bool IsError => ErrorMessage is not null;

    public static Result<T> Success(T value) => new()
    {
        Value = value
    };

    public static Result<T> Error(string errorMessage) => new()
    {
        Value = default!,
        ErrorMessage = errorMessage
    };
}
