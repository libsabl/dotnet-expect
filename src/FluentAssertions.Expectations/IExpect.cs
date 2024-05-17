// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

/// <summary>
/// Dummy interface for utility methods such as Invoking and ExecutionTime
/// </summary>
public interface IExpect { }

[DebuggerNonUserCode]
internal class ExpectImpl : IExpect
{
    private ExpectImpl() { }

    public static ExpectImpl Instance { get; private set; } = new ExpectImpl();
}

public static partial class Expectation
{
    /// <summary>Access expectation utilities such as <c>Invoking</c> and <c>ExecutionTime</c></summary>
    public static IExpect Expect() => ExpectImpl.Instance;
}

/// <summary>
/// Definitions of general APIs such as Invoking(...) and ExecutionTime(...)
/// </summary>
[DebuggerNonUserCode]
public static partial class IExpectExtensions { }
