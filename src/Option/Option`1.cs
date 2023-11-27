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
    /// Creates an <see cref="Option{T}"/> in a 'None' state (without a value).
    /// </summary>
    public static Option<T> None()
    {
        return new Option<T>();
    }
}