Console.WriteLine("orignal = new IntValue(15)");
var orignal = new IntRecord(15);
var refInstance = orignal;
var refInstance2 = (Ref<IntRecord>)(() => orignal);
ref var refInstance3 = ref orignal;
Console.WriteLine($"orign\t: {orignal}");
Console.WriteLine($"=\t: {refInstance}");
Console.WriteLine($"Ref<T>\t: {refInstance2.Get()}");
Console.WriteLine($"ref\t: {refInstance3}");

Console.WriteLine();

orignal = new IntRecord(2);
Console.WriteLine("orignal = new IntValue(2)");

Console.WriteLine($"orign\t: {orignal}");
Console.WriteLine($"=\t: {refInstance}");
Console.WriteLine($"Ref<T>\t: {refInstance2.Get()}");
Console.WriteLine($"ref\t: {refInstance3}");

record IntRecord(int Value);

readonly record struct Ref<T>(Func<T> Get)
{
    //public static explicit operator Ref<T>(Func<T> Get) => new Ref<T>(Get);
    public static implicit operator Ref<T>(Func<T> Get) => new(Get);
}
