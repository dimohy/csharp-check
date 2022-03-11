var task = Task.Run(async () =>
{
    await Task.Delay(30000);
});

Console.WriteLine("Start!");
await task;
Console.WriteLine("Stop!");

