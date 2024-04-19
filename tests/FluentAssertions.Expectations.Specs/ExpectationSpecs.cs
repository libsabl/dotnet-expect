// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations.Specs;

public class ExpectationSpecs
{
    [Fact]
    public void Ctor_Sets_Subject()
    {
        var exp = new Expectation<int>(2);
        Expect(exp.Subject).To().Be(2);
    }
}
