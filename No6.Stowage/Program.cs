using Stowage;

using System.Text;

Console.WriteLine("Storage Test");

using var ms = Files.Of.InternalMemory();

await ms.WriteText(@"test/test.txt", "test", Encoding.UTF8);

//var list = await fs.Ls();
//foreach (var item in list)
//{
//    Console.WriteLine(item.Name);
//    using var fss = await fs.OpenRead(item.Path);
//    using var mss = await ms.OpenWrite(item.Path, WriteMode.CreateNew);

//    await fss.CopyToAsync(mss);
//}

foreach (var item in await ms.Ls(recurse: true))
{
    Console.WriteLine(item);
}

var text = await ms.ReadText("test/test.txt", Encoding.UTF8);
Console.WriteLine($"Read Text: {text}");

await ms.Rm("/test/", recurse: true);

foreach (var item in await ms.Ls(recurse: true))
{
    Console.WriteLine(item);
}
