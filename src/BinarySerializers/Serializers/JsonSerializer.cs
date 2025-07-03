using Newtonsoft.Json;
using System.Text;

namespace BinarySerializers.Serializers;

internal class JsonSerializer
{
    private static readonly JsonSerializerSettings jsonSerializerSettings;
    private static readonly Newtonsoft.Json.JsonSerializer jsonSerializer;

    static JsonSerializer()
    {
        jsonSerializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new PrivateContractResolver()
        };

        jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings);
    }

    public static byte[] SerializeToUtf8Bytes<T>(T instance)
    {
        using StringWriter stringWriter = new();
        jsonSerializer.Serialize(stringWriter, instance);

        return Encoding.UTF8.GetBytes(stringWriter.GetStringBuilder().ToString());
    }

    public static T Deserialize<T>(byte[] buffer)
    {
        JsonReader jsonTextReader = new JsonTextReader(new StringReader(Encoding.UTF8.GetString(buffer)));

        T? entity = jsonSerializer.Deserialize<T>(jsonTextReader);

        return entity is null ? throw new Exception("JSON serialization exception") : entity;
    }
}
