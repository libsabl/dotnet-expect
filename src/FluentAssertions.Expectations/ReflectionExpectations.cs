// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Reflection;
using FluentAssertions.Types;
using System.Reflection;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="Assembly"/> subject</summary>
    public static Expectation<Assembly> Expect(Assembly actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="Type"/> subject</summary>
    public static Expectation<Type> Expect(Type actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="TypeSelector"/> subject</summary>
    public static Expectation<TypeSelector> Expect(TypeSelector actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="ConstructorInfo"/> subject</summary>
    public static Expectation<ConstructorInfo> Expect(ConstructorInfo actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="MethodInfo"/> subject</summary>
    public static Expectation<MethodInfo> Expect(MethodInfo actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="MethodInfoSelector"/> subject</summary>
    public static Expectation<MethodInfoSelector> Expect(MethodInfoSelector actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="PropertyInfo"/> subject</summary>
    public static Expectation<PropertyInfo> Expect(PropertyInfo actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="PropertyInfoSelector"/> subject</summary>
    public static Expectation<PropertyInfoSelector> Expect(PropertyInfoSelector actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> for reflection-related types</summary>
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
    public static AssemblyAssertions To(this Expectation<Assembly> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="Type"/> subject</summary>
    public static TypeAssertions To(this Expectation<Type> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TypeSelector"/> subject</summary>
    public static TypeSelectorAssertions To(this Expectation<TypeSelector> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="ConstructorInfo"/> subject</summary>
    public static ConstructorInfoAssertions To(this Expectation<ConstructorInfo> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="MethodInfo"/> subject</summary>
    public static MethodInfoAssertions To(this Expectation<MethodInfo> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="MethodInfoSelector"/> subject</summary>
    public static MethodInfoSelectorAssertions To(this Expectation<MethodInfoSelector> expectation)
        => expectation.Subject.Should();  

    /// <summary>Compose assertions about the <see cref="PropertyInfo"/> subject</summary>
    public static PropertyInfoAssertions To(this Expectation<PropertyInfo> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="PropertyInfoSelector"/> subject</summary>
    public static PropertyInfoSelectorAssertions To(this Expectation<PropertyInfoSelector> expectation)
        => expectation.Subject.Should();
}
