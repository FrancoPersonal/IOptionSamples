using FluentAssertions;
using IOptionsSample.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOptionsSample.UnitTest
{
    public partial class OptionsExtensionsTest
    {
        [Fact]
        public void When_AddOptionClass_WithObject_Then_NotNull()
        {
            //Arrange
            IConfiguration config = StartUp.BuildConfiguration(null!, false);
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddOptionClass<FakeOptions>(options);
            IFakeClass? fakeClass = GetFakeClass(config, services);

            //Assert
            fakeClass.Should().NotBeNull();
        }

        [Fact]
        public void When_AddOptionfromMemoryCollection_WithObject_Then_NotNull()
        {
            //Arrange
            IConfiguration config = StartUp.BuildConfiguration(settings, false);
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddOptionClass<FakeOptions>(config, nameof(FakeOptions));
            IFakeClass? fakeClass = GetFakeClass(config, services);

            //Assert
            fakeClass.Should().NotBeNull();
        }

        [Fact]
        public void When_AddOptionfromEnvironmentVariables_WithObject_Then_NotNull()
        {
            //Arrange
            IConfiguration config = StartUp.BuildConfiguration(null!, addEnvironment: true);
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddOptionClass<FakeOptions>(config, nameof(FakeOptions));
            IFakeClass? fakeClass = GetFakeClass(config, services);

            //Assert
            fakeClass.Should().NotBeNull();
        }

        [Fact]
        public void When_AddOptionnull_WithObject_Then_ThrowException()
        {
            //Arrange
            IConfiguration config = StartUp.BuildConfiguration(null!, false);
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddOptionClass<FakeOptions>(null!);
            Action act = () => GetFakeClass(config, services);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}