// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Specialized;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about an <see cref="Action"/></summary>
    public static Expectation<Action> Expect(Action subject) => new(subject);

    /// <summary>Create an expectation about a <c>Func&lt;<see cref="Task"/>&gt;</c></summary>
    public static Expectation<Func<Task>> Expect(Func<Task> subject) => new(subject);

    /// <summary>Create an expectation about a <c>Func&lt;<see cref="Task{T}"/>&gt;</c></summary>
    public static Expectation<Func<Task<T>>> Expect<T>(Func<Task<T>> subject) => new(subject);

    /// <summary>Create an expectation about a <see cref="Func{T}"/></summary>
    public static Expectation<Func<T>> Expect<T>(Func<T> subject) => new(subject);

    /// <summary>Create an expectation about a <see cref="TaskCompletionSource{T}"/></summary>
    public static Expectation<TaskCompletionSource<T>> Expect<T>(TaskCompletionSource<T> subject) => new(subject);

    /// <summary>Create an expectation about a <see cref="TaskCompletionSource"/></summary>
    public static Expectation<TaskCompletionSource> Expect(TaskCompletionSource subject) => new(subject);
}

/// <summary>
/// Extensions for function-related expectations
/// </summary>
[DebuggerNonUserCode]
public static class FunctionExpectationExtensions
{
    /*
     * See Should() overloads:
     * 
     * Action                  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L862
     * Func<Task>              : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L872
     * Func<Task<T>>           : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L882
     * Func<T>                 : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L892
     * TaskCompletionSource<T> : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L902
     * TaskCompletionSource    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L931
     */

    /// <summary>Compose assertions about the <see cref="Action"/> subject</summary>
    public static ActionAssertions To(this Expectation<Action> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <c>Func&lt;<see cref="Task"/>&gt;</c> subject</summary>
    public static NonGenericAsyncFunctionAssertions To(this Expectation<Func<Task>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <c>Func&lt;<see cref="Task{T}"/>&gt;</c> subject</summary>
    public static GenericAsyncFunctionAssertions<T> To<T>(this Expectation<Func<Task<T>>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="Func{T}"/> subject</summary>
    public static FunctionAssertions<T> To<T>(this Expectation<Func<T>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TaskCompletionSource{T}"/> subject</summary>
    public static TaskCompletionSourceAssertions<T> To<T>(this Expectation<TaskCompletionSource<T>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TaskCompletionSource"/> subject</summary>
    public static TaskCompletionSourceAssertions To(this Expectation<TaskCompletionSource> expectation)
        => expectation.Subject.Should();
}
