// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

public static partial class IExpectExtensions
{
    /*
     * See Invoking() overloads:
     * 
     * Action<T>        : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L45
     * Func<T,TResult>  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L60
     */

    /// <summary>
    /// Create an expectation about the result of invoking <paramref name="action"/>
    /// on <paramref name="subject"/>. Intended for setting up assertions that invocation
    /// will throw an exception.
    /// </summary>
    public static Expectation<Action> Invoking<T>(this IExpect _, T subject, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(subject, nameof(subject));
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        return Expectation.Expect(() => action(subject));
    }

    /// <summary>
    /// Create an expectation about the result of invoking <paramref name="action"/>
    /// on <paramref name="subject"/>. Intended for setting up assertions that invocation
    /// will throw an exception.
    /// </summary>
    public static Expectation<Func<TResult>> Invoking<T, TResult>(this IExpect _, T subject, Func<T, TResult> action)
    {
        ArgumentNullException.ThrowIfNull(subject, nameof(subject));
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        return Expectation.Expect(() => action(subject));
    }
}
