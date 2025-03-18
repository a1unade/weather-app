namespace ServiceA.Web.Interfaces;

public interface IKafkaProducer<in TMessage>
{
    Task ProduceAsync(TMessage message, CancellationToken cancellationToken);
}