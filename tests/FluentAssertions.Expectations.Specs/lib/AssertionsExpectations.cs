// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Primitives;
using System.Reflection;

namespace FluentAssertions.Expectations.Specs;

internal static class AssertionsExpectations
{
    public static AndConstraint<ObjectAssertions> BeSameAssertionAs(
        this ObjectAssertions wrappedAssertion,
        object expectedAssertion,
        bool unwrapDelegates = false)
    {
        // Input wrappedAssertion is an ObjectAssertion _about_ some other assertion object
        var originalAssertion = wrappedAssertion.Subject;
        var expectedType = expectedAssertion.GetType();
        originalAssertion.Should().BeOfType(expectedType); // Assertion itself should be same as expected assertion type

        // And they should be about the same subject
        var originalSubject = GetSubject(originalAssertion.GetType(), originalAssertion);
        var expectedSubject = GetSubject(expectedType, expectedAssertion);

        if (unwrapDelegates) {
            if (expectedSubject is Delegate delExpected) {
                var delActual = originalSubject.Should().BeAssignableTo<Delegate>().Which;

                var tgtExpected = delExpected.Target;
                var tgtActual = delActual.Target;
                tgtActual.Should().BeEquivalentTo(tgtExpected);
                return new(wrappedAssertion);
            } else {
                throw new InvalidOperationException($"Expected subject is a {expectedSubject?.GetType() ?? null}, not a delegate");
            }
        }

        return originalSubject.Should().Be(expectedSubject);
    }


    private static object? GetSubject(Type type, object assertion)
    {
        var subjectProp = type.GetProperty("Subject", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (subjectProp != null) return subjectProp.GetValue(assertion);

        var subjectField = type.GetField("subject", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (subjectField != null) return subjectField.GetValue(assertion);

        throw new InvalidOperationException($"No Subject property or subject field found on type {type}");
    }
}
