// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Specialized;
using System;

namespace FluentAssertions.Expectations.Specs;

#pragma warning disable IDE0039 // Use local function

public class FunctionExpectationSpecs
{
    [Fact]
    public void Expect_To_Returns_ActionAssertions()
    {
        Action action = () => { };

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(action).To();

        // Assert
        Expect(assertions).To().BeOfType<ActionAssertions>();
        assertions.NotThrow();

        // Verify API equivalency
        var shouldResult = action.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public async Task Expect_To_Returns_NonGenericAsyncFunctionAssertions()
    {
        Func<Task> func = () => Task.CompletedTask;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(func).To();

        // Assert
        Expect(assertions).To().BeOfType<NonGenericAsyncFunctionAssertions>();
        await assertions.NotThrowAsync();

        // Verify API equivalency
        var shouldResult = func.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public async Task Expect_To_Returns_GenericAsyncFunctionAssertions_of_T()
    {
        Func<Task<int>> func = () => Task.FromResult(1);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(func).To();

        // Assert
        Expect(assertions).To().BeOfType<GenericAsyncFunctionAssertions<int>>();
        await assertions.NotThrowAsync();

        // Verify API equivalency
        var shouldResult = func.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_FunctionAssertions_of_T()
    {
        Func<int> func = () => 11;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(func).To();

        // Assert
        Expect(assertions).To().BeOfType<FunctionAssertions<int>>();
        assertions.NotThrow();

        // Verify API equivalency
        var shouldResult = func.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public async Task Expect_To_Returns_TaskCompletionSourceAssertions_of_T()
    {
        TaskCompletionSource<int> tcs = new();

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(tcs).To();

        // Also set the result so the CompleteWithinAsync assertion succeeds
        tcs.SetResult(1);

        // Assert
        Expect(assertions).To().BeOfType<TaskCompletionSourceAssertions<int>>();
        await assertions.CompleteWithinAsync(TimeSpan.FromMilliseconds(1));

        // Verify API equivalency
        var shouldResult = tcs.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public async Task Expect_To_Returns_TaskCompletionSourceAssertions()
    {
        TaskCompletionSource tcs = new();

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(tcs).To();

        // Also set the result so the CompleteWithinAsync assertion succeeds
        tcs.SetResult();

        // Assert
        Expect(assertions).To().BeOfType<TaskCompletionSourceAssertions>();
        await assertions.CompleteWithinAsync(TimeSpan.FromMilliseconds(1));

        // Verify API equivalency
        var shouldResult = tcs.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
