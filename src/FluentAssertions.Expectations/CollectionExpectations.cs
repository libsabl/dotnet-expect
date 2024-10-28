// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about <see cref="IEnumerable{T}"/> values</summary>
[DebuggerNonUserCode]
public static class CollectionExpectationExtensions
{
    /*
    * See Should() overloads:
    * 
    * IEnumerable<T>      : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L342
    * IEnumerable<string> : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L352 
    */

    /// <summary>Compose assertions about the <see cref="IEnumerable{T}"/> subject</summary>
    public static StringCollectionAssertions To(this IExpectation<IEnumerable<string>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="IEnumerable{T}"/> of <see cref="string"/> subject</summary>
    public static GenericCollectionAssertions<T> To<T>(this IExpectation<IEnumerable<T>> expectation)
        => expectation.Subject.Should();
}
