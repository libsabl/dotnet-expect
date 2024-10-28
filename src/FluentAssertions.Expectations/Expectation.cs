// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

/// <summary>
/// Container for all overloads of <c>static Expect(...)</c>
/// </summary>
[DebuggerNonUserCode]
public static partial class Expectation
{
    /// <summary>
    /// Compose assertions about <paramref name="subject"/>
    /// </summary>
    public static IExpectation<T> Expect<T>(T? subject) => new ExpectationValue<T>(subject!);

    [DebuggerNonUserCode]
    private class ExpectationValue<T>(T subject) : IExpectation<T>
    {
        public T Subject { get; } = subject;

        object? IExpectation.Subject => this.Subject;
    }
}

/// <summary>
/// An expectation about a generic <see cref="object"/> <see cref="Subject"/>
/// </summary>
public interface IExpectation
{
    /// <summary>
    /// The subject of the expectation
    /// </summary>
    object? Subject { get; }
}

/// <summary>
/// An expectation about a given <see cref="Subject"/> of a specific type
/// </summary>
public interface IExpectation<out T> : IExpectation
{
    /// <summary>
    /// The subject of the expectation
    /// </summary>
    new T Subject { get; }
}
