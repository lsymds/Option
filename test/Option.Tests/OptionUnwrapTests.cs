namespace LSymds.Option;

public class OptionUnwrapTests
{
    [Fact]
    public void ReturnsTheSomeValue_IfTheOptionIsSome()
    {
        // Arrange.
        var option = Option.Some("Hello, World.");

        // Act.
        var result = option.Unwrap();

        // Assert.
        result.ShouldBe("Hello, World.");
    }

    [Fact]
    public void ThrowsAnInvalidOperationException_IfTheOptionIsNone()
    {
        // Arrange.
        var option = Option.None<string>();

        // Act.
        var func = () => option.Unwrap();

        // Assert.
        func.ShouldThrow<InvalidOperationException>();
    }
}
