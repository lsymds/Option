namespace LSymds.Option;

/// <summary>
/// Wrapper class containing numerous helper methods for interacting with <see cref="Option{T}"/>s.
/// </summary>
public static class Option
{
    /// <summary>
    /// Creates an <see cref="Option{T}"/> without a value in a 'None' state.
    /// </summary>
    /// <typeparam name="T">The type of the option.</typeparam>
    public static Option<T> None<T>()
    {
        return new Option<T>();
    }

    /// <summary>
    /// Creates an <see cref="Option{T}"/> with a value in a 'Some' state.
    /// </summary>
    /// <param name="some">The value to set within the <see cref="Option{T}"/>.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    public static Option<T> Some<T>(T some)
    {
        return new Option<T>(some);
    }
}