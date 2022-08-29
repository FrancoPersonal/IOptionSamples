using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOptionsSample.UnitTest
{
    public partial class OptionsExtensionsTest
    {
        private readonly FakeOptions options;
        private readonly Dictionary<string, string> settings;

        public OptionsExtensionsTest()
        {
            options = new FakeOptions()
            {
                Child = new ChildOption() { Name = "ChildName" },
                Name = "FakeName"
            };

            settings = new Dictionary<string, string>()
            {
                {"FakeOptions:Name",options.Name },
                {"FakeOptions:Child:Name",options.Child.Name }
            };

            foreach (KeyValuePair<string, string> set in settings)
            {
                Environment.SetEnvironmentVariable(set.Key, set.Value);
            }
        }

        private static IFakeClass? GetFakeClass(IConfiguration config, IServiceCollection services)
        {
            StartUp startUp = new(config);
            startUp.ConfigureServices(services);
            ServiceProvider provider = services.BuildServiceProvider();
            IFakeClass? fakeClass = provider.GetService<IFakeClass>();
            return fakeClass;
        }
    }
}