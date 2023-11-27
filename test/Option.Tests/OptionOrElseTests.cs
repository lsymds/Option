namespace LSymds.Option;

public class OptionOrElseTests
{
    [Fact]
    public void ReturnsTheExistingOption_IfTheOptionIsSome()
    {
        // Arrange.
        var option = Option.Some("Hello, world.");

        // Act.
        var result = option.OrElse("foo");

        // Assert.
        result.IsSome.ShouldBeTrue();
        result.IsNone.ShouldBeFalse();
        result.Some.ShouldBe("Hello, world.");
    }

    [Fact]
    public void ReturnsANewOptionWithTheElseValue_IfTheOptionIsNone()
    {
        // Arrange.
        var option = Option.None<string>();
        
        // Act.
        var result = option.OrElse("foo");
        
        // Assert.
        result.IsSome.ShouldBeTrue();
        result.IsNone.ShouldBeFalse();
        result.Some.ShouldBe("foo");
    }
}