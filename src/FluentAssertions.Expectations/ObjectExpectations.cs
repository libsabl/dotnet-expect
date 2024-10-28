// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

/// <summary>
/// Extensions to non-generic <see cref="IExpectation"/>.
/// Implements fallback to <see cref="ObjectAssertions"/> for types
/// that do not have a more specific Should / To extension defined.
/// </summary>
[DebuggerNonUserCode]
public static class ObjectExpectationExtensions
{
    /*
     * See Should() overload:
     * 
     * object : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L282
     */

    /// <summary>Compose assertions about the <see cref="object"/> subject</summary>
    public static ObjectAssertions To(this IExpectation expectation)
       => expectation.Subject.Should();
}
