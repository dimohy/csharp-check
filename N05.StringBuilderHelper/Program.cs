using System.Text;


var nums = new[] { 1, 2, 3, 4, 5 };

var result =
$@"nums {{
    {nums.Foreach(n => $"{n},")}
}}";

Console.WriteLine(result);

var b = $"""""""""""""
        a {'{'}
        b """aaa"""
        c 
        """"""""""""";

Console.WriteLine(b);


public static class StringBuilderExtension
{
    public static StringBuilder Foreach<T>(this IEnumerable<T> enumerable, Func<T, string> funcCallback)
    {
        var result = new StringBuilder();

        foreach (var item in enumerable)
            result.Append(funcCallback?.Invoke(item));

        return result;
    }    
}