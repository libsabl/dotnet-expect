// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="int"/> subject</summary>
    public static Expectation<int> Expect(int actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="int"/> subject</summary>
    public static Expectation<int?> Expect(int? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="uint"/> subject</summary>
    public static Expectation<uint> Expect(uint actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="uint"/> subject</summary>
    public static Expectation<uint?> Expect(uint? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="decimal"/> subject</summary>
    public static Expectation<decimal> Expect(decimal actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="decimal"/> subject</summary>
    public static Expectation<decimal?> Expect(decimal? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="byte"/> subject</summary>
    public static Expectation<byte> Expect(byte actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="byte"/> subject</summary>
    public static Expectation<byte?> Expect(byte? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="sbyte"/> subject</summary>
    public static Expectation<sbyte> Expect(sbyte actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="sbyte"/> subject</summary>
    public static Expectation<sbyte?> Expect(sbyte? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="short"/> subject</summary>
    public static Expectation<short> Expect(short actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="short"/> subject</summary>
    public static Expectation<short?> Expect(short? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="ushort"/> subject</summary>
    public static Expectation<ushort> Expect(ushort actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="ushort"/> subject</summary>
    public static Expectation<ushort?> Expect(ushort? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="long"/> subject</summary>
    public static Expectation<long> Expect(long actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="long"/> subject</summary>
    public static Expectation<long?> Expect(long? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="ulong"/> subject</summary>
    public static Expectation<ulong> Expect(ulong actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="ulong"/> subject</summary>
    public static Expectation<ulong?> Expect(ulong? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="float"/> subject</summary>
    public static Expectation<float> Expect(float actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="float"/> subject</summary>
    public static Expectation<float?> Expect(float? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="double"/> subject</summary>
    public static Expectation<double> Expect(double actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="double"/> subject</summary>
    public static Expectation<double?> Expect(double? actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> about numeric types</summary>
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
    public static NumericAssertions<int> To(this Expectation<int> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="int"/> subject</summary>
    public static NullableNumericAssertions<int> To(this Expectation<int?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="uint"/> subject</summary>
    public static NumericAssertions<uint> To(this Expectation<uint> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="uint"/> subject</summary>
    public static NullableNumericAssertions<uint> To(this Expectation<uint?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="decimal"/> subject</summary>
    public static NumericAssertions<decimal> To(this Expectation<decimal> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="decimal"/> subject</summary>
    public static NullableNumericAssertions<decimal> To(this Expectation<decimal?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="byte"/> subject</summary>
    public static NumericAssertions<byte> To(this Expectation<byte> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="byte"/> subject</summary>
    public static NullableNumericAssertions<byte> To(this Expectation<byte?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="sbyte"/> subject</summary>
    public static NumericAssertions<sbyte> To(this Expectation<sbyte> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="sbyte"/> subject</summary>
    public static NullableNumericAssertions<sbyte> To(this Expectation<sbyte?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="short"/> subject</summary>
    public static NumericAssertions<short> To(this Expectation<short> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="short"/> subject</summary>
    public static NullableNumericAssertions<short> To(this Expectation<short?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="ushort"/> subject</summary>
    public static NumericAssertions<ushort> To(this Expectation<ushort> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="ushort"/> subject</summary>
    public static NullableNumericAssertions<ushort> To(this Expectation<ushort?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="long"/> subject</summary>
    public static NumericAssertions<long> To(this Expectation<long> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="long"/> subject</summary>
    public static NullableNumericAssertions<long> To(this Expectation<long?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="ulong"/> subject</summary>
    public static NumericAssertions<ulong> To(this Expectation<ulong> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="ulong"/> subject</summary>
    public static NullableNumericAssertions<ulong> To(this Expectation<ulong?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="float"/> subject</summary>
    public static NumericAssertions<float> To(this Expectation<float> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="float"/> subject</summary>
    public static NullableNumericAssertions<float> To(this Expectation<float?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="double"/> subject</summary>
    public static NumericAssertions<double> To(this Expectation<double> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="double"/> subject</summary>
    public static NullableNumericAssertions<double> To(this Expectation<double?> expectation)
        => expectation.Subject.Should();
}
