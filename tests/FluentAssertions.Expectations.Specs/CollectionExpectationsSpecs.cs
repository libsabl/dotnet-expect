// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Collections;

namespace FluentAssertions.Expectations.Specs;

public class CollectionExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_GenericCollectionAssertions()
    {
        List<int> listValue = [3, 4, 343, -1];

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(listValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<GenericCollectionAssertions<int>>();
        assertions.BeEquivalentTo([3, 4, 343, -1]);

        // Verify API equivalency
        var shouldResult = listValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_StringCollectionAssertions()
    {
        List<string> listValue = ["a", "b", "another", null!, "two"];

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(listValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<StringCollectionAssertions>();
        assertions.BeEquivalentTo(["a", "b", "another", null!, "two"]);

        // Verify API equivalency
        var shouldResult = listValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
