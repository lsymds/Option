namespace LSymds.Option;

public class OptionUnwrapOrElseTests
{
    [Fact]
    public void ReturnsTheSomeValue_IfTheOptionIsSome()
    {
        // Arrange.
        var option = Option.Some("Hello, World.");

        // Act.
        var result = option.UnwrapOrElse("Goodbye, World.");

        // Assert.
        result.ShouldBe("Hello, World.");
    }

    [Fact]
    public void ReturnsTheElseValue_IfTheOptionIsNone()
    {
        // Arrange.
        var option = Option.None<string>();

        // Act.
        var result = option.UnwrapOrElse("Goodbye, World.");

        // Assert.
        result.ShouldBe("Goodbye, World.");
    }
}
