using System.Diagnostics.CodeAnalysis;

namespace LSymds.Option;

/// <summary>
/// A monad that represents a value that COULD be present.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public record Option<T>
{
    /// <summary>
    /// Gets a boolean indicating whether this option has a value or not.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Some))]
    public bool IsSome { get; }

    /// <summary>
    /// Gets a boolean indicating whether this option does not have a value.
    /// </summary>
    [MemberNotNullWhen(false, nameof(Some))]
    public bool IsNone { get; }

    /// <summary>
    /// Gets the value of this option. Will return null if <see cref="IsNone"/>.
    /// </summary>
    public T? Some { get; }

    /// <summary>
    /// Creates an <see cref="Option{T}"/> in a 'None' state.
    /// </summary>
    internal Option()
    {
        IsSome = false;
        IsNone = true;
    }

    /// <summary>
    /// Creates an <see cref="Option{T}"/> in a 'Some' state with a value.
    /// </summary>
    /// <param name="some">The value to put in the Option.</param>
    internal Option(T some)
    {
        IsSome = true;
        IsNone = false;
        Some = some;
    }

    /// <summary>
    /// UNSAFELY gets the value of <see cref="Some"/> if <see cref="IsSome"/>, else throws an
    /// <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when an attempt is made to get the value of the option when <see cref="IsNone"/> is true.
    /// </exception>
    public T Unwrap()
    {
        if (IsNone)
        {
            throw new InvalidOperationException(
                "Unable to retrieve Some value as Option is in a None state."
            );
        }

        return Some;
    }

    /// <summary>
    /// Gets the value of <see cref="Some"/> if <see cref="IsSome"/>, else returns <see cref="@else"/>.
    /// </summary>
    /// <param name="else">The value to return if <see cref="IsNone"/></param>
    /// <returns></returns>
    public T UnwrapOrElse(T @else)
    {
        return IsSome ? Some : @else;
    }

    /// <summary>
    /// If <see cref="IsSome"/>, maps the value of <see cref="Some"/> to a value of type <see cref="TMap"/>
    /// using the provided mapping function. Otherwise, returns an <see cref="Option{T}"/> in a 'None' state.
    /// </summary>
    /// <param name="someMapper">
    /// The mapper to apply to the current <see cref="Some"/> value if <see cref="IsSome"/>.
    /// </param>
    /// <typeparam name="TMap">The type to map to.</typeparam>
    public Option<TMap> Map<TMap>(Func<T, TMap> someMapper)
    {
        return IsSome ? new Option<TMap>(someMapper(Some)) : new Option<TMap>();
    }

    /// <summary>
    /// Returns the current <see cref="Option"/> if <see cref="IsSome"/>, else returns a new <see cref="Option"/>
    /// in a 'Some' state with a value of <see cref="@else"/>.
    /// </summary>
    /// <param name="else">The alternative value to return if <see cref="IsNone"/>.</param>
    public Option<T> OrElse(T @else)
    {
        return IsSome ? this : new Option<T>(@else);
    }

    /// <summary>
    /// Creates an <see cref="Option{T}"/> in a 'None' state (without a value).
    /// </summary>
    public static Option<T> None()
    {
        return new Option<T>();
    }
}
