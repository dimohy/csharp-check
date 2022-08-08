#if false
// #1
var s = new ReturnableConstructor(out var bInit);
Console.WriteLine(bInit);

class ReturnableConstructor
{
    public ReturnableConstructor(out bool bInit)
    {
        bInit = true;
    }
}
#endif

#if true
// #2
string[] items = { "A", "B", "C", "D", "E", "F" };
var target = "C";
foreach (var item in items)
{
    var result = $"{item.CompareTo(target):크다;작다;같다}";
    Console.WriteLine(result);
}

#endif