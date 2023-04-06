// 문제: 참조하고 있는 인스턴스가 변경되더라도 참조한 값은 변경된 인스턴스가 반영되지 않는다.

// 예)

using System.Runtime.CompilerServices;

var orignal = new IntValue(15);
Console.WriteLine(orignal);

var refInstance = orignal;
var refInstance2 = new Ref<IntValue>(() => orignal);
ref var refInstance3 = ref orignal;

Console.WriteLine($"{refInstance}");
Console.WriteLine($"{refInstance2.Get()}");
Console.WriteLine($"{refInstance3}");

Console.WriteLine();

orignal = new IntValue(2);
Console.WriteLine($"{orignal}");
Console.WriteLine($"{refInstance}");
Console.WriteLine($"{refInstance2.Get()}");
Console.WriteLine($"{refInstance3}");


record IntValue(int Value);

readonly record struct Ref<T>(Func<T> Get);

class HaveRefValue
{
    //private readonly ref IntValue _value;
}