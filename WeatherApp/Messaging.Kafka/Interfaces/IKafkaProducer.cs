namespace Messaging.Kafka.Interfaces;

public interface IKafkaProducer<in TMessage>
{
    Task ProduceAsync(TMessage message, CancellationToken cancellationToken);
}