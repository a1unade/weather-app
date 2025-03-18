using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using ServiceB.Web.Helpers;
using ServiceB.Web.Interfaces;
using WeatherApp.Contracts.Models;

namespace ServiceB.Web.Services;

public class KafkaConsumer: IKafkaConsumer
{
    private readonly IWeatherSenderService _weatherSenderService;
    
    private readonly ILogger<KafkaConsumer> _logger;
    
    private readonly IConsumer<string, WeatherApiResponse> _consumer;
    
    private readonly string _topic;
    
    public KafkaConsumer(IOptions<KafkaOptions> options, IWeatherSenderService weatherSenderService, ILogger<KafkaConsumer> logger)
    {
        ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = options.Value.BootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            GroupId = options.Value.GroupId
        };
        
        _topic = options.Value.Topic;
        _weatherSenderService = weatherSenderService;
        _logger = logger;
        
        _consumer = new ConsumerBuilder<string, WeatherApiResponse>(config)
            .SetValueDeserializer(new KafkaJsonDeserializer<WeatherApiResponse>())
            .Build();
    }

    public async Task ConsumeAsync(CancellationToken cancellationToken)
    {
        _consumer.Subscribe(_topic);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                ConsumeResult<string, WeatherApiResponse> result = _consumer.Consume(cancellationToken);
    
                if (result is null || result.Message.Value is null)
                    continue;
                
                if (result.IsPartitionEOF)
                {
                    _logger.LogWarning($"End of partition at {DateTime.UtcNow}");
                    continue;
                }
                
                await _weatherSenderService.SendWeatherAsync(result.Message.Value, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public void Close() 
        => _consumer.Close();
}