using Messaging.Kafka.Interfaces;
using Messaging.Kafka.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Kafka.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddKafkaProducer<TMessage>(this IServiceCollection serviceCollection, IConfigurationSection configuration)
    {
        serviceCollection.Configure<KafkaSettings>(configuration);
        serviceCollection.AddSingleton<IKafkaProducer<TMessage>, KafkaProducer<TMessage>>();
    }
}