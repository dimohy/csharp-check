using System.Text.Json;
using System.Text.Json.Serialization;


var p = new Person("dimohy", Friend: new("fmsoul", Friend: new("spowner")));

var json = JsonSerializer.Serialize(p, PersonSerializationContext.Default.Person);
Console.WriteLine(json);


public record Person(
    string Name,
    bool IsCool = true,
    Person? Friend = default
);


[JsonSourceGenerationOptions(
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Person))]
public partial class PersonSerializationContext : JsonSerializerContext
{
}

