// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Reflection;
using FluentAssertions.Types;
using System.Reflection;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about reflection-related types</summary>
[DebuggerNonUserCode]
public static class ReflectionExpectationsExtensions
{
    /*
     * See Should() overloads:
     * 
     * Assembly             : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L175
     * Type                 : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L779
     * TypeSelector         : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L790
     * ConstructorInfo      : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L803
     * MethodInfo           : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L813
     * MethodInfoSelector   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L825
     * PropertyInfo         : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L838
     * PropertyInfoSelector : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L850
     */

    /// <summary>Compose assertions about the <see cref="Assembly"/> subject</summary>
    public static AssemblyAssertions To(this IExpectation<Assembly> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="Type"/> subject</summary>
    public static TypeAssertions To(this IExpectation<Type> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TypeSelector"/> subject</summary>
    public static TypeSelectorAssertions To(this IExpectation<TypeSelector> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="ConstructorInfo"/> subject</summary>
    public static ConstructorInfoAssertions To(this IExpectation<ConstructorInfo> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="MethodInfo"/> subject</summary>
    public static MethodInfoAssertions To(this IExpectation<MethodInfo> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="MethodInfoSelector"/> subject</summary>
    public static MethodInfoSelectorAssertions To(this IExpectation<MethodInfoSelector> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="PropertyInfo"/> subject</summary>
    public static PropertyInfoAssertions To(this IExpectation<PropertyInfo> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="PropertyInfoSelector"/> subject</summary>
    public static PropertyInfoSelectorAssertions To(this IExpectation<PropertyInfoSelector> expectation)
        => expectation.Subject.Should();
}
