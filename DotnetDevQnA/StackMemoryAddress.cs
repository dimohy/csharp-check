Test();

unsafe void Test()
{
    var a = 5;

    Console.WriteLine($"{(long)&a:X16}");

    if (a == 5)
    {
        var b = 10;
        Console.WriteLine($"{(long)&b:X16}");
    }

    if (a != 5)
    {
        var c = 15;
        Console.WriteLine($"{(long)&c:X16}");
    }

    if (a == 5)
    {
        var d = 20;
        Console.WriteLine($"{(long)&d:X16}");
    }
}

