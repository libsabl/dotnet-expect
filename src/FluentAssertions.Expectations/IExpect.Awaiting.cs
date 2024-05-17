// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

public static partial class IExpectExtensions
{
    /*
     * See Awaiting() overloads:
     * 
     * Func<T, Task>                : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L73
     * Func<T, Task<TResult>>>      : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L83
     * Func<T, ValueTask>           : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L93
     * Func<T, ValueTask<TResult>>  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L103
     */

    /// <summary>
    /// Create an expectation about the async result of invoking <paramref name="action"/>
    /// on <paramref name="subject"/>. Intended for setting up assertions that awaiting the
    /// returned task with throw an exception.
    /// </summary>
    public static Expectation<Func<Task>> Awaiting<T>(this IExpect _, T subject, Func<T, Task> action)
    {
        ArgumentNullException.ThrowIfNull(subject, nameof(subject));
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        return Expectation.Expect(() => action(subject));
    }

    /// <summary>
    /// Create an expectation about the async result of invoking <paramref name="action"/>
    /// on <paramref name="subject"/>. Intended for setting up assertions that awaiting the
    /// returned task with throw an exception.
    /// </summary>
    public static Expectation<Func<Task<TResult>>> Awaiting<T, TResult>(this IExpect _, T subject, Func<T, Task<TResult>> action)
    {
        ArgumentNullException.ThrowIfNull(subject, nameof(subject));
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        return Expectation.Expect(() => action(subject));
    }

    /// <summary>
    /// Create an expectation about the async result of invoking <paramref name="action"/>
    /// on <paramref name="subject"/>. Intended for setting up assertions that awaiting the
    /// returned task with throw an exception.
    /// </summary>
    public static Expectation<Func<Task>> Awaiting<T>(this IExpect _, T subject, Func<T, ValueTask> action)
    {
        ArgumentNullException.ThrowIfNull(subject, nameof(subject));
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        return Expectation.Expect(() => action(subject).AsTask());
    }

    /// <summary>
    /// Create an expectation about the async result of invoking <paramref name="action"/>
    /// on <paramref name="subject"/>. Intended for setting up assertions that awaiting the
    /// returned task with throw an exception.
    /// </summary>
    public static Expectation<Func<Task<TResult>>> Awaiting<T, TResult>(this IExpect _, T subject, Func<T, ValueTask<TResult>> action)
    {
        ArgumentNullException.ThrowIfNull(subject, nameof(subject));
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        return Expectation.Expect(() => action(subject).AsTask());
    }
}
