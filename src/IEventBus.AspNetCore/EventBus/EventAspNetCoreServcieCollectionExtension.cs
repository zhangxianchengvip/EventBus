using EventBus.Abstractions;
using EventBus.AspNetCore.Configurations;
using EventBus.AspNetCore.EventBus.AspNetCore;
using EventBus.Configurations;
using EventBus.SubsManager;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace EventBus.AspNetCore
{
    public static class EventAspNetCoreServcieCollectionExtension
    {
        public static void UseAspNetCore(this EventBusOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            options.RegisterExtension(new AspNetCoreEventBusServiceCollectionExtension());

        }
    }
}
