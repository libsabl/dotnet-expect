// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Xml;
using System.Xml.Linq;

namespace FluentAssertions.Expectations.Specs;

public class XmlExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_XDocumentAssertions()
    {
        XDocument xDocValue = new(
            new XElement("root",
                new XAttribute("version", 22),
                new XElement("child"),
                new XElement("child")
             )
        );

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(xDocValue).To();

        // Assert
        Expect(assertions).To().BeOfType<XDocumentAssertions>();
        assertions.HaveRoot("root");
        assertions.HaveElement("child");

        // Verify API equivalency
        var shouldResult = xDocValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_XElementAssertions()
    {
        XElement xElValue = new("parent",
            new XAttribute("version", 22),
            new XElement("child"),
            new XElement("child")
        );

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(xElValue).To();

        // Assert
        Expect(assertions).To().BeOfType<XElementAssertions>();
        assertions.HaveAttribute("version", "22");
        assertions.HaveElement("child");

        // Verify API equivalency
        var shouldResult = xElValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_XAttributeAssertions()
    {
        XAttribute xAttrValue = new("version", 22);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(xAttrValue).To();

        // Assert
        Expect(assertions).To().BeOfType<XAttributeAssertions>();
        assertions.HaveValue("22"); 

        // Verify API equivalency
        var shouldResult = xAttrValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
