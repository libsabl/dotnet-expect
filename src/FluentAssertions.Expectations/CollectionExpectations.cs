// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="IEnumerable{T}"/> subject</summary>
    public static CollectionExpectation<T> Expect<T>(IEnumerable<T> actual)
        => new(actual);

    /// <summary>Create an expectation about a <see cref="IEnumerable{T}"/> of <see cref="string"/> subject</summary>
    public static CollectionExpectation<string> Expect(IEnumerable<string> actual)
        => new(actual);
}

/// <summary>An <see cref="Expectation{T}"/> about a <see cref="IEnumerable{T}"/></summary>
[DebuggerNonUserCode]
public class CollectionExpectation<T>(IEnumerable<T> actual) : Expectation<IEnumerable<T>>(actual) { }

/// <summary>Extensions to <see cref="CollectionExpectation{T}"/></summary>
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
    public static StringCollectionAssertions To(this CollectionExpectation<string> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="IEnumerable{T}"/> of <see cref="string"/> subject</summary>
    public static GenericCollectionAssertions<T> To<T>(this CollectionExpectation<T> expectation)
        => expectation.Subject.Should();
}
