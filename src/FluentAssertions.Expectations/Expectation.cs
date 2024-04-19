// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

/// <summary>
/// Container for all overloads of <c>static Expect(...)</c>
/// </summary>
[DebuggerNonUserCode]
public static partial class Expectation { }

/// <summary>
/// An expectation about a given <see cref="Subject"/>
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="subject"></param>
[DebuggerNonUserCode]
public class Expectation<T>(T subject)
{
    /// <summary>
    /// The subject of the expectation
    /// </summary>
    public T Subject { get; } = subject;
}
