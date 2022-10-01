using System.Runtime.InteropServices;
using System.Text;


// TestBeep()

TestLZ4Compress();



static void TestBeep()
{
    for (uint i = 0; i < 100; i++)
    {
        ExternDll.Beep(i * 100, 50);
    }
}

static void TestLZ4Compress()
{
    var sourceText = """
        닷넷 코어는 ASP.NET Core 웹 응용 프로그램, 명령줄 응용 프로그램, 라이브러리 및 유니버셜 윈도우 플랫폼 앱, 응용 프로그램 등 총 4가지로 크로스 플랫폼 시나리오를 지원한다. 다만, 현재 윈도우의 데스크톱 소프트웨어용 표준 GUI를 렌더링하는 윈도우 폼 또는 WPF는 구현되어 있지 않다.[3][4] 이에 마이크로소프트는 닷넷 코어3에서 윈도우 폼, WPF을 유니버셜 윈도우 플랫폼 앱과 함께 지원할 방침이다.[5] 여기에 닷넷 코어는 NuGet 패키지의 사용을 지원한다. 윈도우 버전의 닷넷 프레임워크와는 달리 업데이트는 윈도우 업데이트에서만 주로 이루어지만, 닷넷 코어는 업데이트를 패키지 관리자 형식으로 업데이트를 하는 장점이 있다.[3][4]

        닷넷 코어는 공통 언어 런타임(CLR)의 완전한 런타임환경을 구현시킨 CoreCLR로 구성되어있다. 이 런타임은 닷넷 프로그램 실행 관리를 위한 가상 컴퓨터로 마이크로소프트에서 시작하여, RyuJIT라는 JIT 컴파일을 포함한다.[6] 또한, AOT 컴파일 된 원시 바이너리에 통합되도록 최적화 된 닷넷 원시 런타임인 CoreRT를 포함한다.

        닷넷 코어는 닷넷 프레임워크의 표준 라이브러리의 일부 포크인 CoreFX도 포함되어 있으며,[7] 닷넷 코어의 API의 일부분은 닷넷 프레임워크의 API과 동일한 부분도 있으나, 닷넷 프레임워크와는 전혀 다른 전용 API을 사용한다. 그리고 닷넷 코어의 라이브러리를 변형시켜 UWP의 개발에 활용할 수 있다.[8]

        닷넷 코어의 명령 줄 인터페이스는 운영 체제에 대한 실행 진입 점을 제공하고 컴파일 및 패키지 관리와 같은 개발자 서비스를 제공한다.[9]
        """;

    Console.WriteLine(sourceText);
    Console.WriteLine("------");

    var source = Encoding.Default.GetBytes(sourceText);

    var maxDstSize = ExternDll.LZ4_compressBound(source.Length);
    //Console.WriteLine(maxDstSize);
    var target = new byte[maxDstSize];

    var compressedSize = ExternDll.LZ4_compress_default(source, target, source.Length, maxDstSize);
    Console.WriteLine($"압축 (LZ4 기본)");
    Console.WriteLine($"소스 크기 = {source.Length}");
    Console.WriteLine($"압축된 크기 = {compressedSize}");
    Console.WriteLine($"압축(%) = {(1 - (float)compressedSize / source.Length) * 100} %");
    Console.WriteLine("------");

    var decompressedTarget = new byte[source.Length];
    var decompressedSize = ExternDll.LZ4_decompress_safe(target, decompressedTarget, compressedSize, decompressedTarget.Length);

    Console.WriteLine($"압축 해제 (LZ4 기본)");
    Console.WriteLine($"압축 해제 크기 = {decompressedSize}");

    Console.WriteLine("------");

    var decompressedText = Encoding.Default.GetString(decompressedTarget);
    Console.WriteLine(decompressedText);
}


static partial class ExternDll
{
    [LibraryImport("Kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool Beep(uint freq, uint duration);


    [LibraryImport("msys-lz4-1.dll")]
    public static partial int LZ4_compressBound(int inputSize);

    [LibraryImport("msys-lz4-1.dll")]
    public static partial int LZ4_compress_default(byte[] src, byte[] dst, int srcSize, int dstCapacity);

    [LibraryImport("msys-lz4-1.dll")]
    public static partial int LZ4_decompress_safe(byte[] src, byte[] dst, int compressedSize, int dstCapacity);
}