using Dimohysm.AutoGen.EnumGenerators;

var w = WeekKind.월요일;
Console.WriteLine(w.ToStringFast());



[EnumExtensions]
public enum WeekKind
{
    일요일,
    월요일,
    화요일,
    수요일,
    목요일,
    금요일,
    토요일
}