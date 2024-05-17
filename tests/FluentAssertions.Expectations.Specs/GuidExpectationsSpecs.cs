// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class GuidExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_GuidAssertions()
    {
        Guid guidValue = Guid.Parse("ddc143c9-cfab-4ba4-90a9-36106d59f5b4");

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(guidValue).To();

        // Assert
        Expect(assertions).To().BeOfType<GuidAssertions>();
        assertions.Be("ddc143c9-cfab-4ba4-90a9-36106d59f5b4");

        // Verify API equivalency
        var shouldResult = guidValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableGuidAssertions()
    {
        Guid? guidValue = Guid.Parse("c74be062-320b-49ef-b31e-9aa6d2453cd2");

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(guidValue).To();

        // Assert
        Expect(assertions).To().BeOfType<NullableGuidAssertions>();
        assertions.Be("c74be062-320b-49ef-b31e-9aa6d2453cd2");

        // Verify API equivalency
        var shouldResult = guidValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
