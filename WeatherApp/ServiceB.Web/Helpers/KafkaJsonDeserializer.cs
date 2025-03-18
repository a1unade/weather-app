using System.Text.Json;
using Confluent.Kafka;

namespace ServiceB.Web.Helpers;

public class KafkaJsonDeserializer<TMessage>: IDeserializer<TMessage>
{
    public TMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context) =>
        JsonSerializer.Deserialize<TMessage>(data)!;
}