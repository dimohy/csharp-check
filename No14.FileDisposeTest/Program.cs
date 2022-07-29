var testCount = 100000;

var tempFilename = Path.GetTempFileName();
for (var i = 0; i < testCount; i++)
{
    var s = File.OpenWrite(tempFilename);

    s.WriteByte(1);
    s.WriteByte(2);
    s.WriteByte(3);

    //s.Close();
    // s.Dispose(); // 동일
}