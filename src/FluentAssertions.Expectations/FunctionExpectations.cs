// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Specialized;

namespace FluentAssertions.Expectations;

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
    public static ActionAssertions To(this IExpectation<Action> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <c>Func&lt;<see cref="Task"/>&gt;</c> subject</summary>
    public static NonGenericAsyncFunctionAssertions To(this IExpectation<Func<Task>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <c>Func&lt;<see cref="Task{T}"/>&gt;</c> subject</summary>
    public static GenericAsyncFunctionAssertions<T> To<T>(this IExpectation<Func<Task<T>>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="Func{T}"/> subject</summary>
    public static FunctionAssertions<T> To<T>(this IExpectation<Func<T>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TaskCompletionSource{T}"/> subject</summary>
    public static TaskCompletionSourceAssertions<T> To<T>(this IExpectation<TaskCompletionSource<T>> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TaskCompletionSource"/> subject</summary>
    public static TaskCompletionSourceAssertions To(this IExpectation<TaskCompletionSource> expectation)
        => expectation.Subject.Should();
}
