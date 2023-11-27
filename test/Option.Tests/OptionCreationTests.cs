namespace LSymds.Option;

public class OptionCreationTests
{
    [Fact]
    public void CreatesANoneOption()
    {
        // Act.
        var option = Option.None<string>();

        // Assert.
        option.IsSome.ShouldBeFalse();
        option.IsNone.ShouldBeTrue();
        option.Some.ShouldBeNull();
    }

    [Fact]
    public void CreatesASomeOption()
    {
        // Act.
        var option = Option.Some("hello");

        // Assert.
        option.IsSome.ShouldBeTrue();
        option.IsNone.ShouldBeFalse();
        option.Some.ShouldBe("hello");
    }
}
