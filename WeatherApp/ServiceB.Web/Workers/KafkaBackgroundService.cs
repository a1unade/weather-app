using ServiceB.Web.Interfaces;

namespace ServiceB.Web.Workers;

public class KafkaBackgroundService(
    ILogger<KafkaBackgroundService> logger, 
    IHostApplicationLifetime applicationLifetime,
    IKafkaConsumer consumer): BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        try
        {
            await consumer.ConsumeAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
        finally
        {
            try
            {
                consumer.Close();
                applicationLifetime.StopApplication();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error closing consumer.");
            }
        }
    }
}