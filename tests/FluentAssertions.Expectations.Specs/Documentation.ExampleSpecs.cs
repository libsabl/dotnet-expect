// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Expectations;
using Xunit.Sdk;

namespace Documentation.Example;

public class ExampleSpecs
{
    [Fact]
    public void String_Example_Works()
    {
        string actual = "ABCDEFGHI";
        Expect(actual).To().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
    }

    [Fact]
    public void IntList_Example_Works()
    {
        Expect(() => {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };
            Expect(numbers).To().OnlyContain(n => n > 0);
            Expect(numbers).To().HaveCount(4, "because we thought we put four items in the collection");
        }).To().Throw<XunitException>();
    }
}
