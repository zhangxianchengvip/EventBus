using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Configurations
{
    public interface IEventBusServiceCollectionExtension
    {
        IServiceCollection AddServices(IServiceCollection services);
    }
}
