// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

/// <summary>
/// Container for all overloads of Expect(...)
/// </summary>
[DebuggerNonUserCode]
public static partial class Expectation { }

[DebuggerNonUserCode]
public class Expectation<T>(T subject)
{
    public T Subject { get; } = subject;
}
