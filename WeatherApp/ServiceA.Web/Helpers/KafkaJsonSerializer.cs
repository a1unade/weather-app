using System.Text.Json;
using Confluent.Kafka;

namespace ServiceA.Web.Helpers;

public class KafkaJsonSerializer<TMessage> : ISerializer<TMessage>
{
    public byte[] Serialize(TMessage data, SerializationContext context) =>
        JsonSerializer.SerializeToUtf8Bytes(data);
}