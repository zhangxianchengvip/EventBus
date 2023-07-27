using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Configurations
{
    public class EventBusOptions
    {
        public EventBusOptions()
        {
            ServiceCollectionExtensions = new List<IEventBusServiceCollectionExtension>();
        }

        public List<IEventBusServiceCollectionExtension> ServiceCollectionExtensions { get; set; }

        public void RegisterExtension(IEventBusServiceCollectionExtension extension)
        {
            if (extension is null)
                throw new ArgumentNullException(nameof(extension));
            ServiceCollectionExtensions.Add(extension);
        }
    }
}
