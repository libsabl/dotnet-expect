// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;
using System.Net.Http;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="HttpResponseMessage"/> subject</summary>
    public static Expectation<HttpResponseMessage> Expect(HttpResponseMessage actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> for stream types</summary>
[DebuggerNonUserCode]
public static class HttpExpectationExtensions
{
    /*
    * See Should() overload:
    * 
    * HttpResponseMessage : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L312
    */

    /// <summary>Compose assertions about the <see cref="HttpResponseMessage"/> subject</summary>
    public static HttpResponseMessageAssertions To(this Expectation<HttpResponseMessage> expectation)
        => expectation.Subject.Should();
}
