// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations.Specs;

public class ComparableExpectationSpecs
{
    private readonly struct MyComparable(int value) : IComparable<MyComparable>
    {
        public readonly int Value => value;

        public readonly int CompareTo(MyComparable other)
          => value.CompareTo(other.Value);
    }

    [Fact]
    public void Expect_To_Returns_ComparableTypeAssertions()
    {
        var compValue = new MyComparable(11);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(compValue).To();

        // Assert
        Expect(assertions).To().BeOfType<ComparableTypeAssertions<MyComparable>>();
        assertions.BeGreaterThan(new MyComparable(10));

        // Verify API equivalency
        var shouldResult = compValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
