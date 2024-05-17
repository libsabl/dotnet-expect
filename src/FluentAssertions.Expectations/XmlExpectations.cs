using FluentAssertions.Xml;
using System.Xml.Linq;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="XDocument"/> subject</summary>
    public static Expectation<XDocument> Expect(XDocument actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="XElement"/> subject</summary>
    public static Expectation<XElement> Expect(XElement actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="XAttribute"/> subject</summary>
    public static Expectation<XAttribute> Expect(XAttribute actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> for System.Xml.Linq types</summary>
[DebuggerNonUserCode]
public static class XmlExpectationExtensions
{
    /*
    * See Should() overloads:
    * 
    * XDocument  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L185
    * XElement   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L195
    * XAttribute : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L205 
    */

    /// <summary>Compose assertions about the <see cref="XDocument"/> subject</summary>
    public static XDocumentAssertions To(this Expectation<XDocument> expectation)
     => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="XElement"/> subject</summary>
    public static XElementAssertions To(this Expectation<XElement> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="XAttribute"/> subject</summary>
    public static XAttributeAssertions To(this Expectation<XAttribute> expectation)
        => expectation.Subject.Should();
}
