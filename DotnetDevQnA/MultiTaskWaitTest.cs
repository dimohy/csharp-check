
var feNets = Enumerable.Range(1, 10).Select(x => new FeNet(x)).ToArray();

Console.WriteLine("Test1");
await Test1Async(feNets);

Console.WriteLine("------");

Console.WriteLine("Test2");
await Test2Async(feNets);


// 순차적으로 실행됨
static async Task Test1Async(FeNet[] feNets)
{
    foreach (var feNet in feNets)
    {
        var result = await feNet.ReceiveAsync();
        Console.WriteLine(result);

    }
}

// 한번에 실행됨
static async Task Test2Async(FeNet[] feNets)
{
    var tasks = feNets.Select(x => x.ReceiveAsync()).ToArray();
    await Task.WhenAll(tasks);

    foreach (var task in tasks)
        Console.WriteLine(task.Result);
}

// 예시를 위한 클래스
class FeNet
{
    public int Id { get; }

    public FeNet(int id)
    {
        Id = id;
    }

    public async Task<int> ReceiveAsync()
    {
        await Task.Delay(Random.Shared.Next(100, 1000));

        return Id;
    }
}