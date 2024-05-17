// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class StringExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_StringAssertions()
    {
        string strValue = "hello";

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(strValue).To();

        // Assert
        Expect(assertions).To().BeOfType<StringAssertions>();
        assertions.Be("hello");

        // Verify API equivalency
        var shouldResult = strValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
