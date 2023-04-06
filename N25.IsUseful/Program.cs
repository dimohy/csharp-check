var input = "15,2";

// 1. 입력 값을 변수에 담는 일반적인 방법
var items = input.Split(',');
var (a, b) = (items[0], items[1]);

// 2. LINQ를 쓸 수도 있음
(a, b) = input.Split(',').Chunk(2).Select(x => (x[0], x[1])).First();

// 3. is를 사용하면 비교문에서 사용할 수 있음
var bResult = input.Split(',') is string[] items2 is true && items2[0] is "15" && items2[1] is "2";
Console.WriteLine(bResult);

Console.WriteLine($"a={a}, b={b}");
