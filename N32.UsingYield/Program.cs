// 피보나치 수 출력
foreach (var n in GetFibonacciNumbers().Take(10))
    Console.WriteLine(n);

Console.WriteLine();

// 콜라츠 수 출력
foreach (var n in GetCollatzNumbers(15))
    Console.WriteLine(n);

// 피보나치 수
static IEnumerable<int> GetFibonacciNumbers()
{
    var x = 0;
    var y = 1;

    while (true)
    {
        yield return x;
        (x, y) = (y, x + y);
    }
}

// 콜라츠 수
static IEnumerable<int> GetCollatzNumbers(int n)
{
    if (n < 0)
        throw new ArgumentOutOfRangeException();

    var current = n;
    while (current != 1)
    {
        yield return current;

        if (current % 2 is 0)
            current /= 2;
        else
            current = current * 3 + 1;
    }
    yield return current;
}