using System.Diagnostics.CodeAnalysis;

namespace LSymds.Option;

/// <summary>
/// A monad that represents a value that COULD be present.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public class Option<T>
{
    /// <summary>
    /// Gets a boolean indicating whether this option has a value or not.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Some))]
    public bool IsSome { get; }
    
    /// <summary>
    /// Gets a boolean indicating whether this option does not have a value.
    /// </summary>
    public bool IsNone { get; }
    
    /// <summary>
    /// Gets the value of this option. Will return null if <see cref="IsSome"/> is false.
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
    /// <param name="some"></param>
    internal Option(T some)
    {
        IsSome = true;
        IsNone = false;
        Some = some;
    }

    /// <summary>
    /// If <see cref="IsSome"/> is true, maps the value of <see cref="Some"/> to a value of type <see cref="TMap"/>
    /// using the provided mapping function. Otherwise, returns an <see cref="Option{T}"/> in a 'None' state.
    /// </summary>
    /// <param name="someMapper">
    /// The mapper to apply to the current <see cref="Some"/> value if <see cref="IsSome"/> is true.
    /// </param>
    /// <typeparam name="TMap">The type to map to.</typeparam>
    public Option<TMap> Map<TMap>(Func<T, TMap> someMapper)
    {
        return IsSome
            ? new Option<TMap>(someMapper(Some))
            : new Option<TMap>();
    }

    /// <summary>
    /// Returns the current <see cref="Option"/> if <see cref="IsSome"/> is true, else returns a new <see cref="Option"/>
    /// in a 'Some' state with a value of <see cref="@else"/>.
    /// </summary>
    /// <param name="else">The alternative value to return if <see cref="IsNone"/> is true.</param>
    public Option<T> OrElse(T @else)
    {
        return IsSome
            ? this
            : new Option<T>(@else);
    }

    /// <summary>
    /// Creates an <see cref="Option{T}"/> in a 'None' state (without a value).
    /// </summary>
    public static Option<T> None()
    {
        return new Option<T>();
    }
}