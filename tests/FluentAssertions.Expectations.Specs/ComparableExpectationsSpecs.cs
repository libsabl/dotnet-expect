// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations.Specs;

public class ComparableExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_ComparableTypeAssertions()
    {
        Version versionValue = new(23, 2, 1);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(versionValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<ComparableTypeAssertions<Version>>();
        assertions.Be(new(23, 2, 1));

        // Verify API equivalency
        var shouldResult = versionValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    } 
}
