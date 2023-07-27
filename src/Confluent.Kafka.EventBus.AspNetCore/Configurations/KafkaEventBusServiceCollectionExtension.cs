using Confluent.Kafka;
using Confluent.Kafka.AspNetCore;
using EventBus.Abstractions;
using EventBus.Configurations;
using EventBus.Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.Confluent.Kafka.Configurations
{
    public class KafkaEventBusServiceCollectionExtension : IEventBusServiceCollectionExtension
    {
        public KafkaEventBusServiceCollectionExtension(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration configuration { get; set; }

        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddConfluentKafkaProducer<string, string>(configuration);
            services.AddConfluentKafkaConsumer<Ignore, byte[]>(configuration);
            services.AddSingleton<IEventBus, ConfluentKafkaEventBus>();
            return services;
        }
    }
}