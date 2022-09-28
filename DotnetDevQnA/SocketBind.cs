//소켓 생성
using System.Net.Sockets;
using System.Net;


var ipAddress = "192.168.100.46";
var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
var ipep = new IPEndPoint(IPAddress.Parse(ipAddress), 5000);
socket.Bind(ipep);
socket.Listen(5);

_ = socket.AcceptAsync().ContinueWith(async x =>
{
    var socket = await x;
    var buffer = new byte[1024].AsMemory();
    //await received = socket.ReceiveAsync(buffer, SocketFlags.None)
});

Console.ReadLine();
