// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class BoolExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_BooleanAssertions()
    {
        bool boolValue = true;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(boolValue).To();

        // Assert
        Expect(assertions).To().BeOfType<BooleanAssertions>();
        assertions.Be(true);

        // Verify API equivalency
        var shouldResult = boolValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableBooleanAssertions()
    {
        bool? boolValue = true;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(boolValue).To();

        // Assert
        Expect(assertions).To().BeOfType<NullableBooleanAssertions>();
        assertions.Be(true);

        // Verify API equivalency
        var shouldResult = boolValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
