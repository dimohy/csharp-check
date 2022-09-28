// 비트 필드를 취해야 하는 데이터가 '2비트 모드', '4비트 명렁어', '10비트 데이터'라고 가정
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

ushort raw = 0b01_0010_1000000001;

var dataSection = BitVector32.CreateSection(0b1111111111);
var commandSection = BitVector32.CreateSection(0b1111 , dataSection);
var modeSection = BitVector32.CreateSection(0b11, commandSection);

var data = new BitVector32(raw);

Console.WriteLine(data);
Console.WriteLine($"Mode = {data[modeSection]}");
Console.WriteLine($"Command = {data[commandSection]}");
Console.WriteLine($"Data = {data[dataSection]}");

Console.WriteLine("---");

Console.WriteLine($"Mode = {raw.GetBitField(14, 2)}");
Console.WriteLine($"Command = {raw.GetBitField(10, 4)}");
Console.WriteLine($"Data = {raw.GetBitField(0, 10)}");


static class BitFieldExtension
{
    public static void SetBitField(this ushort @this, int bitOffset, int bits)
    {
        // ...
    }

    public static int GetBitField(this ushort @this, int bitOffset, int bits)
    {
        var mask = (1 << (bitOffset + bits)) - 1;
        return (@this & mask) >> bitOffset;
    }
}
