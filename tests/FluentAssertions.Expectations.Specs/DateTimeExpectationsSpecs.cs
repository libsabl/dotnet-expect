// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations.Specs;

public class DateTimeExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_DateTimeAssertions()
    {
        DateTime dateTimeValue = new DateTime(1970, 01, 01, 12, 34, 56, 789);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dateTimeValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<DateTimeAssertions>();
        assertions.Be(new DateTime(1970, 01, 01, 12, 34, 56, 789));

        // Verify API equivalency
        var shouldResult = dateTimeValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableDateTimeAssertions()
    {
        DateTime? dateTimeValue = new DateTime(1970, 01, 01, 12, 34, 56, 789);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dateTimeValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableDateTimeAssertions>();
        assertions.Be(new DateTime(1970, 01, 01, 12, 34, 56, 789));

        // Verify API equivalency
        var shouldResult = dateTimeValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_DateTimeOffsetAssertions()
    {
        DateTimeOffset dateTimeOffsetValue = new DateTimeOffset(1970, 01, 01, 12, 34, 56, 789, TimeSpan.Zero);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dateTimeOffsetValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<DateTimeOffsetAssertions>();
        assertions.Be(new DateTimeOffset(1970, 01, 01, 12, 34, 56, 789, TimeSpan.Zero));

        // Verify API equivalency
        var shouldResult = dateTimeOffsetValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableDateTimeOffsetAssertions()
    {
        DateTimeOffset? dateTimeOffsetValue = new DateTimeOffset(1970, 01, 01, 12, 34, 56, 789, TimeSpan.Zero);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dateTimeOffsetValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableDateTimeOffsetAssertions>();
        assertions.Be(new DateTimeOffset(1970, 01, 01, 12, 34, 56, 789, TimeSpan.Zero));

        // Verify API equivalency
        var shouldResult = dateTimeOffsetValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_DateOnlyAssertions()
    {
        DateOnly dateOnlyValue = new DateOnly(1970, 01, 01);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dateOnlyValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<DateOnlyAssertions>();
        assertions.Be(new DateOnly(1970, 01, 01));

        // Verify API equivalency
        var shouldResult = dateOnlyValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableDateOnlyAssertions()
    {
        DateOnly? dateOnlyValue = new DateOnly(1970, 01, 01);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dateOnlyValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableDateOnlyAssertions>();
        assertions.Be(new DateOnly(1970, 01, 01));

        // Verify API equivalency
        var shouldResult = dateOnlyValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_TimeOnlyAssertions()
    {
        TimeOnly timeOnlyValue = new TimeOnly(12, 34, 56, 789);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(timeOnlyValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<TimeOnlyAssertions>();
        assertions.Be(new TimeOnly(12, 34, 56, 789));

        // Verify API equivalency
        var shouldResult = timeOnlyValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableTimeOnlyAssertions()
    {
        TimeOnly? timeOnlyValue = new TimeOnly(12, 34, 56, 789);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(timeOnlyValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableTimeOnlyAssertions>();
        assertions.Be(new TimeOnly(12, 34, 56, 789));

        // Verify API equivalency
        var shouldResult = timeOnlyValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_SimpleTimeSpanAssertions()
    {
        TimeSpan timeSpanValue = TimeSpan.FromMilliseconds(2309);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(timeSpanValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<SimpleTimeSpanAssertions>();
        assertions.Be(TimeSpan.FromMilliseconds(2309));

        // Verify API equivalency
        var shouldResult = timeSpanValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_NullableSimpleTimeSpanAssertions()
    {
        TimeSpan? timeSpanValue = TimeSpan.FromMilliseconds(2309);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(timeSpanValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<NullableSimpleTimeSpanAssertions>();
        assertions.Be(TimeSpan.FromMilliseconds(2309));

        // Verify API equivalency
        var shouldResult = timeSpanValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}
