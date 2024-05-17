// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="Guid"/> subject</summary>
    public static Expectation<Guid> Expect(Guid actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="Guid"/> subject</summary>
    public static Expectation<Guid?> Expect(Guid? actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> about Guid values</summary>
[DebuggerNonUserCode]
public static class GuidExpectationExtensions
{
    /*
     * See Should() overloads:
     * 
     * Guid  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L322
     * Guid? : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L332
     */

    /// <summary>Compose assertions about the <see cref="Guid"/> subject</summary>
    public static GuidAssertions To(this Expectation<Guid> expectation)
       => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="Guid"/> subject</summary>
    public static NullableGuidAssertions To(this Expectation<Guid?> expectation)
       => expectation.Subject.Should();
}
