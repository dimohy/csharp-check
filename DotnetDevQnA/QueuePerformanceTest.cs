using System.Collections.Concurrent;
using System.Diagnostics;

var q = new ConcurrentQueue<byte>();
var sw = Stopwatch.StartNew();
for (var i = 0; i < 1000000; i++)
{
    q.Enqueue(123);
}
Console.WriteLine(sw.ElapsedMilliseconds);

sw.Restart();
for (var i = 0; i < 1000000; i++)
{
    q.TryDequeue(out var value);
}
Console.WriteLine(sw.ElapsedMilliseconds);


Console.WriteLine("!!");


