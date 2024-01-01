namespace LSymds.Option;

public class OptionOrElseTests
{
    public class Static
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

    public class Lambda
    {
        [Fact]
        public void ReturnsTheExistingOption_AndDoesNotEvaluateTheElseLambda_IfTheOptionIsSome()
        {
            // Arrange.
            var check = false;
            string Func()
            {
                check = true;
                return "foo";
            }

            var option = Option.Some("Hello, world.");

            // Act.
            var result = option.OrElse(Func);

            // Assert.
            result.IsSome.ShouldBeTrue();
            result.IsNone.ShouldBeFalse();
            result.Some.ShouldBe("Hello, world.");
            check.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsANewOptionWithTheEvaluatedLambda_IfTheOptionIsNone()
        {
            // Arrange.
            var option = Option.None<string>();

            // Act.
            var result = option.OrElse(() => "foo");

            // Assert.
            result.IsSome.ShouldBeTrue();
            result.IsNone.ShouldBeFalse();
            result.Some.ShouldBe("foo");
        }
    }
}
