using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOptionsSample.UnitTest
{
    public class StartUp
    {
        private readonly IConfiguration configuration;

        public StartUp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        internal IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFakeClass, FakeClass>();
            return services;
        }

        internal static IConfiguration BuildConfiguration(
            Dictionary<string, string> settings,
            bool addEnvironment
            )
        {
            ConfigurationBuilder configbuilder = new ConfigurationBuilder();
            if (settings != null)
            {
                configbuilder.AddInMemoryCollection(settings);
            }
            if (addEnvironment)
            {
                configbuilder.AddEnvironmentVariables();
            }
            return configbuilder.Build();
        }
    }
}