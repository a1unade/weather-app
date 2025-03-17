using Confluent.Kafka;
using Messaging.Kafka.Helpers;
using Messaging.Kafka.Interfaces;
using Messaging.Kafka.Options;
using Microsoft.Extensions.Options;

namespace Messaging.Kafka;

public class KafkaProducer<TMessage> : IKafkaProducer<TMessage>
{
    private readonly IProducer<string, TMessage> _producer;
    
    private readonly string _topic;
    
    public KafkaProducer(IOptions<KafkaSettings> options)
    {
        ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = options.Value.BootstrapServers,
        };

        _producer = new ProducerBuilder<string, TMessage>(config)
            .SetValueSerializer(new KafkaJsonSerializer<TMessage>())
            .Build();
        
        _topic = options.Value.Topic;
    }
    
    public async Task ProduceAsync(TMessage message, CancellationToken cancellationToken)
    {
        await _producer.ProduceAsync(_topic, new Message<string, TMessage>
        {
            Key = "weather-key",
            Value = message
        }, cancellationToken);
    }
}