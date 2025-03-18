using ServiceB.Web.Helpers;
using ServiceB.Web.Interfaces;
using ServiceB.Web.Services;

namespace ServiceB.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddKafkaConsumer(this IServiceCollection serviceCollection, IConfigurationSection configuration)
    {
        serviceCollection.Configure<KafkaOptions>(configuration);
        serviceCollection.AddSingleton<IKafkaConsumer, KafkaConsumer>();
    }
}