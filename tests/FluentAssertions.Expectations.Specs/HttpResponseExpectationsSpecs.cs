using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class HttpResponseExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_HttpResponseMessageAssertions()
    {
        var response = new HttpResponseMessage() {
            StatusCode = System.Net.HttpStatusCode.OK,
            Headers = {
                { "E-Tag", "sadjeupodapsdkja34k2kj" },
                { "Some-Header", "the value" }
            },
            Content = new StringContent("""
            {
                "number": 1,
                "string": "value",
                "object": {
                    "a": 2,
                    "b": true
                }
            }
            """)
        };

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(response).To();

        // Assert
        Expect(assertions).To().BeOfType<HttpResponseMessageAssertions>();
        assertions.HaveStatusCode(System.Net.HttpStatusCode.OK);

        // Verify API equivalency
        var shouldResult = response.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
