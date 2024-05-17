// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="DateTime"/> subject</summary>
    public static Expectation<DateTime> Expect(DateTime actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="DateTime"/> subject</summary>
    public static Expectation<DateTime?> Expect(DateTime? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="DateTimeOffset"/> subject</summary>
    public static Expectation<DateTimeOffset> Expect(DateTimeOffset actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="DateTimeOffset"/> subject</summary>
    public static Expectation<DateTimeOffset?> Expect(DateTimeOffset? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="DateOnly"/> subject</summary>
    public static Expectation<DateOnly> Expect(DateOnly actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="DateOnly"/> subject</summary>
    public static Expectation<DateOnly?> Expect(DateOnly? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="TimeOnly"/> subject</summary>
    public static Expectation<TimeOnly> Expect(TimeOnly actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="TimeOnly"/> subject</summary>
    public static Expectation<TimeOnly?> Expect(TimeOnly? actual) => new(actual);

    /// <summary>Create an expectation about a <see cref="TimeSpan"/> subject</summary>
    public static Expectation<TimeSpan> Expect(TimeSpan actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="TimeSpan"/> subject</summary>
    public static Expectation<TimeSpan?> Expect(TimeSpan? actual) => new(actual);
}

/// <summary>Extensions to <see cref="Expectation{T}"/> about date and time types</summary>
[DebuggerNonUserCode]
public static class DateTimeExpectationExtensions
{
    /*
    * See Should() overloads:
    * 
    * DateTime        : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L436
    * DateTime?       : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L456
    * DateTimeOffset  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L446
    * DateTimeOffset? : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L466
    * DateOnly        : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L477
    * DateOnly?       : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L487
    * TimeOnly        : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L497
    * TimeOnly?       : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L507
    * TimeSpan        : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L759
    * TimeSpan?       : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L769
    */

    /// <summary>Compose assertions about the <see cref="DateTime"/> subject</summary>
    public static DateTimeAssertions To(this Expectation<DateTime> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="DateTime"/> subject</summary>
    public static NullableDateTimeAssertions To(this Expectation<DateTime?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="DateTimeOffset"/> subject</summary>
    public static DateTimeOffsetAssertions To(this Expectation<DateTimeOffset> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="DateTimeOffset"/> subject</summary>
    public static NullableDateTimeOffsetAssertions To(this Expectation<DateTimeOffset?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="DateOnly"/> subject</summary>
    public static DateOnlyAssertions To(this Expectation<DateOnly> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="DateOnly"/> subject</summary>
    public static NullableDateOnlyAssertions To(this Expectation<DateOnly?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TimeOnly"/> subject</summary>
    public static TimeOnlyAssertions To(this Expectation<TimeOnly> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="TimeOnly"/> subject</summary>
    public static NullableTimeOnlyAssertions To(this Expectation<TimeOnly?> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="TimeSpan"/> subject</summary>
    public static SimpleTimeSpanAssertions To(this Expectation<TimeSpan> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="TimeSpan"/> subject</summary>
    public static NullableSimpleTimeSpanAssertions To(this Expectation<TimeSpan?> expectation)
        => expectation.Subject.Should();
}
