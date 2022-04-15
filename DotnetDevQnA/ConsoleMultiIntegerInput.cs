Console.Write("X, Y ? ");
var input = Console.ReadLine();

// 구분자를 이용하는 방법
var values = input!.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(x =>
    {
        var bResult = int.TryParse(x, out var value);
        return (Result: bResult, Value: value);
    }).ToArray();

if (values.Length >= 2)
{
    Console.WriteLine($"X: {values[0]}, Y: {values[1]}");
}


//var twoArgs = ExtensionMethods.ReadLineArgs(',').Take(2);
//foreach (var arg in twoArgs)
//{
//    Console.WriteLine("!!" + arg);
//}


//public static class ExtensionMethods
//{
//    public static IEnumerable<string> ReadLineArgs(char? separator = ' ')
//    {
//        while (true)
//        {
//            var key = Console.ReadKey();
//            if (key.KeyChar == separator)
//                Console.WriteLine("!!");
//        }
//    }
//}