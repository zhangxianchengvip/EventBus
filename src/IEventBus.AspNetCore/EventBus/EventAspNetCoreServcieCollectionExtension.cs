using EventBus.Abstractions;
using EventBus.AspNetCore.EventBus.AspNetCore;
using EventBus.SubsManager;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.AspNetCore
{
    public static class EventAspNetCoreServcieCollectionExtension
    {
        public static IServiceCollection AddAspNetCoreEventBus(this IServiceCollection services)
        {
            services.AddEventBus();
            services.AddSingleton<IEventBus, AspNetCoreEventBus>();
            foreach (var topic in SubscriptionsManager.GetTopics())
            {
                ChannelManager.AddChannel(topic);
            }
            return services;
        }
    }
}
