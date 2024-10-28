// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about a string</summary>
[DebuggerNonUserCode]
public static class StringExpectationExtensions
{
    /*
     * See Should() overload:
     * 
     * string : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L749
     */

    /// <summary>Compose assertions about the <see cref="string"/> subject</summary>
    public static StringAssertions To(this IExpectation<string> expectation)
       => expectation.Subject.Should();
}
