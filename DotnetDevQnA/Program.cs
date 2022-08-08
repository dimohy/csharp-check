#if true

var aa = new MySum();
Console.WriteLine(aa.C);

class MySum
{
    private int _a = 8;
    private int _b = 10;
    public int C => _a + _b;
}



#endif




#if false

Console.WriteLine("!");

Func<Task> funcAsync = () => Task.CompletedTask;
await funcAsync();
await funcAsync();

Func<Task>? funcAsync2 = null;
await (funcAsync2?.Invoke() ?? Task.CompletedTask);

Func<Task>? funcAsync3 = null;
await funcAsync3.InvokeAsync();

public static class FuncTaskExtension
{
    public static Task InvokeAsync(this Func<Task>? @this) => @this?.Invoke() ?? Task.CompletedTask;
}

#endif



#if false

var v = new Test();
// init 속성임에도 컴파일 오류는 나지 않음

// init 속성이므로 초기화 이후 설정은 불가능. 컴파일 오류
//v.Value = 123;

v = new Test { Value = 12 };

class Test
{
    public object Value { get; init; } = default!;
}

readonly record struct RecordStruct(int Value);

#endif

#if false

// var lines = File.ReadAllLines("text.txt");
var lines = new string[]
{
    "A\tB\tC\tD\tE\t1",
    "A\tB\tC\tD\tE\t2",
    "A\tB\tC\tD\tE\t3",
    "A\tB\tC\tD\tE\t4",
    "A\tB\tC\tD\tE\t5",
};

var result = lines.Select(x => x.Split('\t').Last());
foreach (var value in result)
    Console.WriteLine(value);

#endif


#if false

var groupList = new List<TextBoxGroup>
{
    // 0
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 1
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 2
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 3
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 4
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 5
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 6
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 7
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
    // 8
    new() {
        TextBoxes = new TextBox[]
        {
            new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new()
        }
    },
};

var number = 0;
foreach (var group in groupList)
{
    foreach (var textbox in group.TextBoxes)
        Console.WriteLine($"{number}: {textbox}");

    number++;
}


class TextBoxGroup
{
    public TextBox[] TextBoxes { get; init; } = default!;

    public TextBoxGroup()
    {
    }
}

/// <summary>
/// TextBox가 있다고 가정
/// </summary>
class TextBox
{
    public string Uuid { get; } = Guid.NewGuid().ToString();

    public override string ToString() => $"TextBox({Uuid})";
}

#endif