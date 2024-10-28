// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about numeric types</summary>
[DebuggerNonUserCode]
public static class ComparableExpectationExtensions
{
    /// <summary>Compose assertions about the <see cref="int"/> subject</summary>
    public static ComparableTypeAssertions<T> To<T>(this IExpectation<T> expectation)
        where T : IComparable<T>
        => expectation.Subject.Should();

}
