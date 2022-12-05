using System.Net;
using System.Net.Quic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


const long DefaultStreamErrorCodeClient = 123456;
const long DefaultStreamErrorCodeServer = 654321;
const long DefaultCloseErrorCodeClient = 789;
const long DefaultCloseErrorCodeServer = 987;

SslApplicationProtocol ApplicationProtocol = new SslApplicationProtocol("quictest");


await using QuicListener listener = await CreateQuicListener();
var clientStreamTask = CreateQuicConnection(listener.LocalEndPoint);
await using QuicConnection serverConnection = await listener.AcceptConnectionAsync();
await using QuicConnection clientConnection = await clientStreamTask;


ValueTask<QuicConnection> CreateQuicConnection(IPEndPoint endpoint)
{
    var options = CreateQuicClientOptions(endpoint);
    return CreateQuicConnection2(options);
}

SslClientAuthenticationOptions GetSslClientAuthenticationOptions()
{
    return new SslClientAuthenticationOptions()
    {
        ApplicationProtocols = new List<SslApplicationProtocol>() { ApplicationProtocol },
        RemoteCertificateValidationCallback = RemoteCertificateValidationCallback,
        TargetHost = "localhost"
    };
}

bool RemoteCertificateValidationCallback(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
{
    return true;
}

QuicClientConnectionOptions CreateQuicClientOptions(EndPoint endpoint)
{
    return new QuicClientConnectionOptions()
    {
        DefaultStreamErrorCode = DefaultStreamErrorCodeClient,
        DefaultCloseErrorCode = DefaultCloseErrorCodeClient,
        RemoteEndPoint = endpoint,
        ClientAuthenticationOptions = GetSslClientAuthenticationOptions()
    };
}

ValueTask<QuicConnection> CreateQuicConnection2(QuicClientConnectionOptions clientOptions)
{
    return QuicConnection.ConnectAsync(clientOptions);
}

ValueTask<QuicListener> CreateQuicListener(int MaxInboundUnidirectionalStreams = 100, int MaxInboundBidirectionalStreams = 100)
{
    var options = CreateQuicListenerOptions();
    return CreateQuicListener2(options);
}

ValueTask<QuicListener> CreateQuicListener2(QuicListenerOptions options) => QuicListener.ListenAsync(options);

QuicListenerOptions CreateQuicListenerOptions()
{
    return new QuicListenerOptions()
    {
        ListenEndPoint = new IPEndPoint(IPAddress.Loopback, 0),
        ApplicationProtocols = new List<SslApplicationProtocol>() { ApplicationProtocol },
        ConnectionOptionsCallback = (_, _, _) => ValueTask.FromResult(CreateQuicServerOptions())
    };
}

QuicServerConnectionOptions CreateQuicServerOptions()
{
    return new QuicServerConnectionOptions()
    {
        DefaultStreamErrorCode = DefaultStreamErrorCodeServer,
        DefaultCloseErrorCode = DefaultCloseErrorCodeServer,
        ServerAuthenticationOptions = GetSslServerAuthenticationOptions()
    };
}

SslServerAuthenticationOptions GetSslServerAuthenticationOptions()
{
    return new SslServerAuthenticationOptions()
    {
        ApplicationProtocols = new List<SslApplicationProtocol>() { ApplicationProtocol },
        //ServerCertificate = 
    };
}
