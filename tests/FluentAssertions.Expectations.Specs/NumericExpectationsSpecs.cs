// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Numeric;

namespace FluentAssertions.Expectations.Specs;

public class NumericExpectationSpecs
{
    [Fact]
    public void Expect_To_Returns_NumericAssertions_int()
    {
        int intValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(intValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<int>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = intValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_int()
    {
        int? intValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(intValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<int>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = intValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_uint()
    {
        uint uintValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(uintValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<uint>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = uintValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_uint()
    {
        uint? uintValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(uintValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<uint>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = uintValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_decimal()
    {
        decimal decimalValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(decimalValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<decimal>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = decimalValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_decimal()
    {
        decimal? decimalValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(decimalValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<decimal>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = decimalValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_byte()
    {
        byte byteValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(byteValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<byte>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = byteValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_byte()
    {
        byte? byteValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(byteValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<byte>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = byteValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_sbyte()
    {
        sbyte sbyteValue = 117;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(sbyteValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<sbyte>>();
        assertions.Be(117);

        // Verify API equivalency
        var shouldResult = sbyteValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_sbyte()
    {
        sbyte? sbyteValue = 117;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(sbyteValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<sbyte>>();
        assertions.Be(117);

        // Verify API equivalency
        var shouldResult = sbyteValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_short()
    {
        short shortValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(shortValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<short>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = shortValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_short()
    {
        short? shortValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(shortValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<short>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = shortValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_ushort()
    {
        ushort ushortValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(ushortValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<ushort>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = ushortValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_ushort()
    {
        ushort? ushortValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(ushortValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<ushort>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = ushortValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_long()
    {
        long longValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(longValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<long>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = longValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_long()
    {
        long? longValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(longValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<long>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = longValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_ulong()
    {
        ulong ulongValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(ulongValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<ulong>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = ulongValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_ulong()
    {
        ulong? ulongValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(ulongValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<ulong>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = ulongValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_float()
    {
        float floatValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(floatValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<float>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = floatValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_float()
    {
        float? floatValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(floatValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<float>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = floatValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NumericAssertions_double()
    {
        double doubleValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(doubleValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NumericAssertions<double>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = doubleValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableNumericAssertions_double()
    {
        double? doubleValue = 232;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(doubleValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<double>>();
        assertions.Be(232);

        // Verify API equivalency
        var shouldResult = doubleValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
