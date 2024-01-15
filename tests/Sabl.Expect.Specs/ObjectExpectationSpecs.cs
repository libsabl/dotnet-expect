// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class ObjectExpectationSpecs
{
    [Fact]
    public void Expect_Returns_ObjectAssertions()
    {
        object objValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(objValue).To();

        // Assert
        Expect(assertions).To().BeOfType<ObjectAssertions>();
        assertions.Be(232);
    }
}
