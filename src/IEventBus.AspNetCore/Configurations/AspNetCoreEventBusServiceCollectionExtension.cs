using EventBus.Abstractions;
using EventBus.AspNetCore.EventBus.AspNetCore;
using EventBus.Configurations;
using EventBus.SubsManager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.AspNetCore.Configurations
{
    public sealed class AspNetCoreEventBusServiceCollectionExtension : IEventBusServiceCollectionExtension
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, AspNetCoreEventBus>();
            foreach (var topic in SubscriptionsManager.GetTopics())
            {
                ChannelManager.AddChannel(topic);
            }
            return services;
        }
    }
}
