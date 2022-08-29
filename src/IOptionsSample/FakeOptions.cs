namespace IOptionsSample
{
    public record FakeOptions
    {
        public string Name { get; set; } = default!;

        public ChildOption Child { get; set; } = default!;
    }
}