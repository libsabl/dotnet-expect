using FluentAssertions.Primitives;
using System.Net.Http;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about <see cref="HttpResponseMessage"/></summary>
[DebuggerNonUserCode]
public static class HttpResponseMessageExpectationExtensions
{
    /// <summary>Compose assertions about the <see cref="HttpResponseMessage"/> subject</summary>
    public static HttpResponseMessageAssertions To(this IExpectation<HttpResponseMessage> expectation)
        => expectation.Subject.Should();
}
