using MQTTnet;
using MQTTnet.Client.Options;

using System.Text.Json;
using MQTTnet.Client.Disconnecting;

var factory = new MqttFactory();
using var client = factory.CreateMqttClient();
var options = new MqttClientOptionsBuilder()
    .WithTcpServer("broker.hivemq.com").Build();
var response = await client.ConnectAsync(options, CancellationToken.None);

var output = "NULL";
if (response != null)
{
    output = JsonSerializer.Serialize(response, new JsonSerializerOptions
    {
        WriteIndented = true
    });
}

Console.WriteLine($"[{response?.GetType().Name}]:\r\n{output}");

var disconnectOptions = new MqttClientDisconnectOptions();
await client.DisconnectAsync(disconnectOptions, CancellationToken.None);
