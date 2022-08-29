using Ardalis.GuardClauses;
using Microsoft.Extensions.Options;

namespace IOptionsSample
{
    public class FakeClass : IFakeClass
    {
        private readonly FakeOptions parameters;

        public FakeClass(IOptions<FakeOptions> parameters)
        {
            this.parameters = Guard.Against.Null(parameters.Value, nameof(parameters));
            Guard.Against.Null(this.parameters.Name, nameof(this.parameters.Name));
            Guard.Against.Null(this.parameters.Child.Name, "Child.Name");
        }

        public FakeOptions TestMetod()
        {
            return parameters;
        }
    }
}