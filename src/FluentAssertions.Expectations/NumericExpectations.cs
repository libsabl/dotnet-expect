// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations;

/// <summary>Extensions to <see cref="IExpectation{T}"/> about numeric types</summary>
[DebuggerNonUserCode]
public static class NumericExpectationExtensions
{
    /*
    * See Should() overloads:
    * 
    * int      : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L529
    * int?     : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L539
    * uint     : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L549
    * uint?    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L559
    * decimal  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L569
    * decimal? : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L579
    * byte     : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L589
    * byte?    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L599
    * sbyte    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L609
    * sbyte?   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L619
    * short    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L629
    * short?   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L639
    * ushort   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L649
    * ushort?  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L659
    * long     : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L669
    * long?    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L679
    * ulong    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L689
    * ulong?   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L699
    * float    : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L709
    * float?   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L719
    * double   : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L729
    * double?  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L739
    */

    /// <summary>Compose assertions about the <see cref="int"/> subject</summary>
    public static NumericAssertions<int> To(this IExpectation<int> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="int"/> subject</summary>
    public static NullableNumericAssertions<int> To(this IExpectation<int?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="uint"/> subject</summary>
    public static NumericAssertions<uint> To(this IExpectation<uint> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="uint"/> subject</summary>
    public static NullableNumericAssertions<uint> To(this IExpectation<uint?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="decimal"/> subject</summary>
    public static NumericAssertions<decimal> To(this IExpectation<decimal> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="decimal"/> subject</summary>
    public static NullableNumericAssertions<decimal> To(this IExpectation<decimal?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="byte"/> subject</summary>
    public static NumericAssertions<byte> To(this IExpectation<byte> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="byte"/> subject</summary>
    public static NullableNumericAssertions<byte> To(this IExpectation<byte?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="sbyte"/> subject</summary>
    public static NumericAssertions<sbyte> To(this IExpectation<sbyte> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="sbyte"/> subject</summary>
    public static NullableNumericAssertions<sbyte> To(this IExpectation<sbyte?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="short"/> subject</summary>
    public static NumericAssertions<short> To(this IExpectation<short> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="short"/> subject</summary>
    public static NullableNumericAssertions<short> To(this IExpectation<short?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="ushort"/> subject</summary>
    public static NumericAssertions<ushort> To(this IExpectation<ushort> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="ushort"/> subject</summary>
    public static NullableNumericAssertions<ushort> To(this IExpectation<ushort?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="long"/> subject</summary>
    public static NumericAssertions<long> To(this IExpectation<long> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="long"/> subject</summary>
    public static NullableNumericAssertions<long> To(this IExpectation<long?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="ulong"/> subject</summary>
    public static NumericAssertions<ulong> To(this IExpectation<ulong> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="ulong"/> subject</summary>
    public static NullableNumericAssertions<ulong> To(this IExpectation<ulong?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="float"/> subject</summary>
    public static NumericAssertions<float> To(this IExpectation<float> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="float"/> subject</summary>
    public static NullableNumericAssertions<float> To(this IExpectation<float?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="double"/> subject</summary>
    public static NumericAssertions<double> To(this IExpectation<double> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="double"/> subject</summary>
    public static NullableNumericAssertions<double> To(this IExpectation<double?> expectation)
        => expectation.Subject.Should();
}
