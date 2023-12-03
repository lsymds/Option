# Option

An option monad implementation in .NET. Build more resilient applications by relying on explicit code instead of
compiler hints.

# Getting Started

## Installing

Install the NuGet package:

```sh
dotnet add package LSymds.Option
```

## Creating options

You create options by calling the `Some<T>` or `None<T>` methods on the `Option` static class. This builds an `Option<T>`
that is in a Some or None state respectively.

For example, to create a Some `Option<T>`:

```csharp
var option = Option.Some("Hello, World!");
return option.IsSome ? option.Some : "Unknown value";
```

and to create a None `Option<T>` of the same `string` type:

```csharp
return Option.None<string>();
```

## Utilities

Lots of utility methods exist that hang off of an interact with the `Option<T>` type.

- `Unwrap` - Retrieves the Some value of an option or throws an `InvalidOperationException` if the option is None.
- `UnwrapOrElse` - Retrieves the Some value of an option or the provided alternative value.
- `Map` - Applies the provided function to the Some value of an existing option or returns the existing option if the
  option is None.
- `OrElse` - Returns the existing option if the option is Some or the provided option if it is None.
