namespace ServiceB.Web.Interfaces;

public interface IKafkaConsumer
{
    Task ConsumeAsync(CancellationToken cancellationToken);
}