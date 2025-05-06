using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConfigurationTool.Common.ConfigurationFactory
{
    //The factory was used instead of Ioptions(Static snapshot at startup) / IOptionsMonitor (Reflects update changes)
    //to inject a single item where its needed and use it to build the needed config file instead of pollution constructors.
    public class ConfigurationFactory : IConfigurationFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ConfigurationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetConfig<T>() where T : class
        {
            var optionsMonitor = _serviceProvider.GetRequiredService<IOptionsMonitor<T>>();
            return optionsMonitor.CurrentValue;
        }
    }
}
