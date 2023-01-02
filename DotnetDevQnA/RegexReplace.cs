using System.Text.RegularExpressions;

var replaced = Regex.Replace("서   물    시  여    의 도", @"서(\s*)물(\s*)시", match => $"서{match.Groups[1]}울{match.Groups[2]}시");
Console.WriteLine(replaced);
