// Copyright 2024 Joshua Honig. All rights reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.

using FluentAssertions.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="IDictionary{TKey, TValue}"/> subject</summary>
    public static DictionaryExpectation<IDictionary<TKey, TValue>, TKey, TValue> Expect<TKey, TValue>(
        IDictionary<TKey, TValue> actual
    ) => new(actual);

    /// <summary>Create an expectation about a <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> subject</summary>
    public static DictionaryExpectation<IEnumerable<KeyValuePair<TKey, TValue>>, TKey, TValue> Expect<TKey, TValue>(
        IEnumerable<KeyValuePair<TKey, TValue>> actual
    ) => new(actual);

    /// <summary>
    /// Create an expectation about a subject whose type <typeparamref name="TCollection"/>
    /// implements <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/>
    /// </summary>
    public static DictionaryExpectation<TCollection, TKey, TValue> Expect<TCollection, TKey, TValue>(
        TCollection actual
    ) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>> => new(actual);
}

/// <summary>
/// An <see cref="Expectation{T}"/> about a type <typeparamref name="TCollection"/> which
/// implements <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/>
/// </summary>
[DebuggerNonUserCode]
public class DictionaryExpectation<TCollection, TKey, TValue>(TCollection actual)
    : Expectation<TCollection>(actual)
    where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
{ }

/// <summary>Extensions to <see cref="DictionaryExpectation{TCollection, TKey, TValue}"/></summary>
[DebuggerNonUserCode]
public static class DictionaryExpectationExtensions
{
    /*
    * See Should() overloads:
    * 
    * IDictionary<TKey, TValue>               : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L362
    * IEnumerable<KeyValuePair<TKey, TValue>> : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L373
    * TCollection                             : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L384
    */

    /// <summary>Compose assertions about the <see cref="IDictionary{TKey, TValue}"/> subject</summary>
    public static GenericDictionaryAssertions<IDictionary<TKey, TValue>, TKey, TValue> To<TKey, TValue>(
       this DictionaryExpectation<IDictionary<TKey, TValue>, TKey, TValue> expectation)
           => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> subject</summary>
    public static GenericDictionaryAssertions<IEnumerable<KeyValuePair<TKey, TValue>>, TKey, TValue> To<TKey, TValue>(
        this DictionaryExpectation<IEnumerable<KeyValuePair<TKey, TValue>>, TKey, TValue> expectation)
            => expectation.Subject.Should();

    /// <summary>
    /// Compose assertions about the subject whose type <typeparamref name="TCollection"/>
    /// implements <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/>
    /// </summary>
    public static GenericDictionaryAssertions<TCollection, TKey, TValue> To<TCollection, TKey, TValue>(
        this DictionaryExpectation<TCollection, TKey, TValue> expectation) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
            => expectation.Subject.Should<TCollection, TKey, TValue>();
}
