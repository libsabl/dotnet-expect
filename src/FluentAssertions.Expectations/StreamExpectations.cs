// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Streams;
using System.IO;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="Stream"/> subject</summary>
    public static Expectation<Stream> Expect(Stream actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="BufferedStream"/> subject</summary>
    public static Expectation<BufferedStream> Expect(BufferedStream actual) => new(actual);
}


/// <summary>Extensions to <see cref="Expectation{T}"/> for stream types</summary>
[DebuggerNonUserCode]
public static class StreamExpectationExtensions
{
    /// <summary>Compose assertions about the <see cref="Stream"/> subject</summary>
    public static StreamAssertions To(this Expectation<Stream> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="Stream"/> subject</summary>
    public static BufferedStreamAssertions To(this Expectation<BufferedStream> expectation)
        => expectation.Subject.Should();
}
