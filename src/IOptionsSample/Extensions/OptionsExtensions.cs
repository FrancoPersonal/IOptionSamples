using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IOptionsSample.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddOptionClass<TOptions>(
            this IServiceCollection services,
            IConfiguration configuration,
            string section
            ) where TOptions : class
        {
            return services.Configure<TOptions>
                (options => configuration
                .GetSection(section)
                .Bind(options));
        }

        public static IServiceCollection AddOptionClass<TOptions>(
         this IServiceCollection services,
         TOptions option
         ) where TOptions : class
        {
            services.AddSingleton<IOptions<TOptions>>(
            provider => Options.Create<TOptions>(option));
            return services.AddTransient<TOptions>();
        }
    }
}