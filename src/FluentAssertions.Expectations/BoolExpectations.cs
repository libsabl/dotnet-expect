// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;
 
/// <summary>Extensions to <see cref="IExpectation{T}"/> about <see cref="bool"/> values</summary>
[DebuggerNonUserCode]
public static class BoolExpectationExtensions
{
    /*
     * See Should() overload:
     * 
     * bool  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L292
     * bool? : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L302
     */

    /// <summary>Compose assertions about the <see cref="bool"/> subject</summary>
    public static BooleanAssertions To(this IExpectation<bool> expectation)
       => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="bool"/> subject</summary>
    public static NullableBooleanAssertions To(this IExpectation<bool?> expectation)
       => expectation.Subject.Should();
}
