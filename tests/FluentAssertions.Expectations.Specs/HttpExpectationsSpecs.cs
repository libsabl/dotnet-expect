// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class HttpExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_HttpResponseMessageAssertions()
    {
        var msgValue = new HttpResponseMessage() {
            StatusCode = System.Net.HttpStatusCode.BadGateway
        };

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(msgValue).To();

        // Assert
        Expect(assertions).To().BeOfType<HttpResponseMessageAssertions>();
        assertions.HaveServerError();

        // Verify API equivalency
        var shouldResult = msgValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
