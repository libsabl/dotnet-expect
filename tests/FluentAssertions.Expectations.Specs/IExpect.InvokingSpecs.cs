// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Specialized;

#pragma warning disable IDE0039 // Use local function

namespace FluentAssertions.Expectations.Specs;

public class IExpectInvokingSpecs
{
    [Fact]
    public void Expect_Invoking_To_Returns_ActionAssertions()
    {
        Action<int> action = n => { _ = n / 0; };
        int subject = 2;

        // Act: Testing Expect().Invoking(...).To() itself
        var assertions = Expect().Invoking(subject, action).To();

        // Assert
        Expect(assertions).To().BeOfType<ActionAssertions>();

        // Also exercise the assertion:
        assertions.Throw<DivideByZeroException>();

        // Verify API equivalency
        var shouldResult = subject.Invoking(action).Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, unwrapDelegates: true);
    }

    [Fact]
    public void Expect_Invoking_To_Returns_FunctionAssertions()
    {
        Func<Guid, string> action = g => g.ToString("invalid format");
        var subject = Guid.NewGuid();

        // Act: Testing Expect().Invoking(...).To() itself
        var assertions = Expect().Invoking(subject, action).To();

        // Assert
        Expect(assertions).To().BeOfType<FunctionAssertions<string>>();

        // Also exercise the assertion:
        assertions.Throw<FormatException>();

        // Verify API equivalency
        var shouldResult = subject.Invoking(action).Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, unwrapDelegates: true);
    }
}
