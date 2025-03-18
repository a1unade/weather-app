using ServiceA.Web.Helpers;
using ServiceA.Web.Interfaces;
using ServiceA.Web.Services;

namespace ServiceA.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddKafkaProducer<TMessage>(this IServiceCollection serviceCollection, IConfigurationSection configuration)
    {
        serviceCollection.Configure<KafkaOptions>(configuration);
        serviceCollection.AddSingleton<IKafkaProducer<TMessage>, KafkaProducer<TMessage>>();
    }
}
