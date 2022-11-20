using static System.Net.Mime.MediaTypeNames;

var a = Parse<int>("4");
Console.WriteLine(a);

static T Parse<T>(string s, IFormatProvider? provider = default)
    where T : IParsable<T>
{
    return T.Parse(s, provider);
}




var result = HaveTemp<int>.Parse("15");
Console.WriteLine(result);

class HaveTemp<T> : IParse<T>
    where T : new()
{
    public static T Parse(string text)
    {
        return new T();
    }
}


interface IParse<T>
{
    static abstract T Parse(string text);
} 