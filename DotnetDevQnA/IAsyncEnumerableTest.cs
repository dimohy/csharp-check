using System.Runtime.CompilerServices;


var cts = new CancellationTokenSource();
var count = 0;
await foreach (var plcResult in ListenPLCEnumerator(cts.Token))
{
    Console.WriteLine($"{plcResult} PLC 수신");

    // 10개만 처리하고 종료
    count++;
    if (count == 10)
        cts.Cancel();
}

static async IAsyncEnumerable<PLCResult> ListenPLCEnumerator([EnumeratorCancellation] CancellationToken ct)
{
    while (ct.IsCancellationRequested is false)
    {
        var number = Random.Shared.Next(100, 500);
        await Task.Delay(number);
        yield return new PLCResult(number);
    }
}

record PLCResult(int number);