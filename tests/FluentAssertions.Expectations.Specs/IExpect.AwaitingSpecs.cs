using FluentAssertions.Specialized;

#pragma warning disable IDE0039 // Use local function

namespace FluentAssertions.Expectations.Specs;

public class IExpectAwaitingSpecs
{
    [Fact]
    public async Task Awaiting_To_Returns_NonGenericAsyncFunctionAssertions()
    {
        Func<int, Task> action = n => Task.FromException(new ArgumentException($"Invalid number {n}"));
        int subject = 2;

        // Act: Testing Expect().Invoking(...).To() itself
        var assertions = Expect().Awaiting(subject, action).To();

        // Assert
        Expect(assertions).To().BeOfType<NonGenericAsyncFunctionAssertions>();

        // Also exercise the assertion:
        await assertions.ThrowAsync<ArgumentException>();

        // Verify API equivalency
        var shouldResult = subject.Awaiting(action).Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, unwrapDelegates: true);    
    }

    [Fact]
    public async Task Awaiting_To_Returns_GenericAsyncFunctionAssertions_of_T()
    {
        Func<int, Task<int>> action = n => Task.FromException<int>(new ArgumentException($"Invalid number {n}"));
        int subject = 2;

        // Act: Testing Expect().Invoking(...).To() itself
        var assertions = Expect().Awaiting(subject, action).To();

        // Assert
        Expect(assertions).To().BeOfType<GenericAsyncFunctionAssertions<int>>();

        // Also exercise the assertion:
        await assertions.ThrowAsync<ArgumentException>();

        // Verify API equivalency
        var shouldResult = subject.Awaiting(action).Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, unwrapDelegates: true);
    }

    [Fact]
    public async Task Awaiting_ValueTask_To_Returns_NonGenericAsyncFunctionAssertions()
    {
        Func<int, ValueTask> action = n => ValueTask.FromException(new ArgumentException($"Invalid number {n}"));
        int subject = 2;

        // Act: Testing Expect().Invoking(...).To() itself
        var assertions = Expect().Awaiting(subject, action).To();

        // Assert
        Expect(assertions).To().BeOfType<NonGenericAsyncFunctionAssertions>();

        // Also exercise the assertion:
        await assertions.ThrowAsync<ArgumentException>();

        // Verify API equivalency
        var shouldResult = subject.Awaiting(action).Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, unwrapDelegates: true);
    }

    [Fact]
    public async Task Awaiting_ValueTask_To_Returns_GenericAsyncFunctionAssertions_of_T()
    {
        Func<int, ValueTask<int>> action = n => ValueTask.FromException<int>(new ArgumentException($"Invalid number {n}"));
        int subject = 2;

        // Act: Testing Expect().Invoking(...).To() itself
        var assertions = Expect().Awaiting(subject, action).To();

        // Assert
        Expect(assertions).To().BeOfType<GenericAsyncFunctionAssertions<int>>();

        // Also exercise the assertion:
        await assertions.ThrowAsync<ArgumentException>();

        // Verify API equivalency
        var shouldResult = subject.Awaiting(action).Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, unwrapDelegates: true);
    }
}
