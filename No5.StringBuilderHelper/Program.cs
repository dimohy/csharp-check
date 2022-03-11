using System.Text;


var nums = new[] { 1, 2, 3, 4, 5 };

var result =
$@"nums {{
    {nums.Foreach((s, n) => s.Append($"{n}, "))}
}}";

Console.WriteLine(result);


public static class StringBuilderExtension
{
    public static StringBuilder Foreach<T>(this IEnumerable<T> enumerable, Action<StringBuilder, T> funcCallback)
    {
        var result = new StringBuilder();

        foreach (var item in enumerable)
        {
            funcCallback?.Invoke(result, item);
        }

        return result;
    }    
}