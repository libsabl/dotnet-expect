﻿// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about Guid values</summary>
[DebuggerNonUserCode]
public static class GuidExpectationExtensions
{
    /*
     * See Should() overload:
     * 
     * Guid  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L322
     * Guid? : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L332
     */

    /// <summary>Compose assertions about the <see cref="Guid"/> subject</summary>
    public static GuidAssertions To(this IExpectation<Guid> expectation)
       => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="Guid"/> subject</summary>
    public static NullableGuidAssertions To(this IExpectation<Guid?> expectation)
       => expectation.Subject.Should();
}
