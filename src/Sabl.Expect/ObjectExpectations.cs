// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions;
using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    public static ObjectExpectation Expect(object? actual)
        => new(actual);
}

[DebuggerNonUserCode]
public class ObjectExpectation(object? actual) : Expectation<object?>(actual) { }

[DebuggerNonUserCode]
public static class ObjectExpectationExtensions
{
    public static ObjectAssertions To(this ObjectExpectation expectation)
       => expectation.Subject.Should();
}
