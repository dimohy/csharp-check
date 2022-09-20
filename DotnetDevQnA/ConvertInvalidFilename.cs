using System.Text;

(char, char)[] _fileInvalidCharMap =
{
    ('\\', '＼'),
    ('/', '／'),
    (':', '：'),
    ('*', '＊'),
    ('?', '？'),
    ('"', '＂'),
    ('<', '＜'),
    ('>', '＞'),
    ('|', '｜')
};


//var filename = "A: B, [test] <123>.txt";
var filename = "＼／：＊？＂＜＞｜.txt";
var newFilename = GetConvertName(filename);
Console.WriteLine(newFilename);
newFilename = GetOriginalName(newFilename);
Console.WriteLine(newFilename);
Console.WriteLine(filename == newFilename);


string GetOriginalName(string name)
{
    var result = new StringBuilder();

    foreach (var c in name)
    {
        var index = Array.FindIndex(_fileInvalidCharMap, x => x.Item2 == c);
        if (index < 0)
        {
            result.Append(c);
            continue;
        }

        result.Append(_fileInvalidCharMap[index].Item1);
    }

    return result.ToString();
}

string GetConvertName(string name)
{
    var result = new StringBuilder();

    foreach (var c in name)
    {
        var index = Array.FindIndex(_fileInvalidCharMap, x => x.Item1 == c);
        if (index < 0)
        {
            result.Append(c);
            continue;
        }

        result.Append(_fileInvalidCharMap[index].Item2);
    }

    return result.ToString();
}
