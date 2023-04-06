var asciiTable = Enumerable.Range(0, 128)
    .Select(x => $"{(char)(x < 32 ? 32 : x)} {x.ToString().PadLeft(3, ' ')} {x:X}")
    .Chunk(32);

foreach (var s in asciiTable)
{
    Console.WriteLine(s);
}