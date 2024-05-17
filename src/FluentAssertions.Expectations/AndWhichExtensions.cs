// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

namespace FluentAssertions.Expectations;

/// <summary>
/// Extension methods to terminate a chain and extract the subject for further assertions
/// </summary>
public static class AndWhichExtensions
{
    /// <summary>
    /// Extract the single result of a prior assertion that is used to select a nested or collection item.
    /// <br/>Synonym for <c>Subject(out TMatchedElement)</c>, <c>Which(out TMatchedElement)</c>
    /// </summary>
    public static void As<TParentConstraint, TMatchedElement>(
        this AndWhichConstraint<TParentConstraint, TMatchedElement> constraint, out TMatchedElement subject)
    {
        subject = constraint.Subject;
    }
}
