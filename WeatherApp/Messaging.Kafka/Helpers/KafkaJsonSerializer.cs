using System.Text.Json;
using Confluent.Kafka;

namespace Messaging.Kafka.Helpers;

public class KafkaJsonSerializer<TMessage> : ISerializer<TMessage>
{
    public byte[] Serialize(TMessage data, SerializationContext context) =>
        JsonSerializer.SerializeToUtf8Bytes(data);
}