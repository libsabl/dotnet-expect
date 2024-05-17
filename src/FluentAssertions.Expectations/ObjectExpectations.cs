// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
 
using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a plain <see cref="object"/> subject</summary>
    public static ObjectExpectation Expect(object? subject) => new(subject);
}

/// <summary>An <see cref="Expectation{T}"/> about a plain <see cref="object"/></summary>
[DebuggerNonUserCode]
public class ObjectExpectation(object? subject) : Expectation<object?>(subject) { }

/// <summary>Extensions to <see cref="ObjectExpectation"/></summary>
[DebuggerNonUserCode]
public static class ObjectExpectationExtensions
{
    /*
     * See Should() overload:
     * 
     * object : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L282
     */

    /// <summary>Compose assertions about the <see cref="object"/> subject</summary>
    public static ObjectAssertions To(this ObjectExpectation expectation)
       => expectation.Subject.Should();
}
