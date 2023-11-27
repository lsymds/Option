namespace LSymds.Option;

public class OptionMapTests
{
    [Fact]
    public void AppliesTheMappingFunction_WhenTheOptionIsSome()
    {
        // Arrange.
        var option = Option.Some("Hello, World.");
        
        // Act.
        var result = option.Map(o => o.Length);
        
        // Assert.
        result.IsSome.ShouldBeTrue();
        result.IsNone.ShouldBeFalse();
        result.Some.ShouldBe(13);
    }

    [Fact]
    public void LeavesTheNewOptionAsNone_WhenTheOptionIsNone()
    {
        // Arrange.
        var option = Option.None<string>();
        
        // Act.
        var result = option.Map(o => o);
        
        // Assert.
        result.IsSome.ShouldBeFalse();
        result.IsNone.ShouldBeTrue();
        result.Some.ShouldBeNull();
    }
}