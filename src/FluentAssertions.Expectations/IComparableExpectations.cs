// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="IComparable{T}"/> subject</summary>
    public static Expectation<IComparable<T>> Expect<T>(IComparable<T> actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> about numeric types</summary>
[DebuggerNonUserCode]
public static class ComparableExpectationExtensions
{
    /// <summary>Compose assertions about the <see cref="int"/> subject</summary>
    public static ComparableTypeAssertions<T> To<T>(this Expectation<IComparable<T>> expectation)
        => expectation.Subject.Should();

}
