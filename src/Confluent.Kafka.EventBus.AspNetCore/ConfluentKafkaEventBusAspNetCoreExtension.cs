using EventBus.Configurations;
using EventBus.Confluent.Kafka.Configurations;
using Microsoft.Extensions.Configuration;

namespace EventBus.Confluent.Kafka
{
    public static class ConfluentKafkaEventBusAspNetCoreExtension
    {
        public static void UseKafka(this EventBusOptions options, IConfiguration configuration)
        {
            options.RegisterExtension(new KafkaEventBusServiceCollectionExtension(configuration));
        }
    }
}