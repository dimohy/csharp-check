﻿#if true

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