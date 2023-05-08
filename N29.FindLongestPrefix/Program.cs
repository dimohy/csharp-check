string[] input = { "flower", "flight", "fly", "flow" };
string result = LongestCommonPrefixFun(input);
Console.WriteLine("Longest Common Prefix is- " + result); // Output: "fl"

static string LongestCommonPrefixFun(string[] input)
{
    if (input.Length is 0)
        return string.Empty;

    var minLength = input.Min(x => x.Length);
    for (var i = 0; i < minLength; i++)
    {
        if (input.Select(x => x[i]).Any(x => x != input[0][i]) is true)
            return input[0][..i];
    }

    return input[0][..minLength];
}
