using FluentAssertions.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Expectations;

public static partial class Expectation
{
    /// <summary>Create an expectation about a <see cref="IEnumerable{T}"/> subject</summary>
    public static CollectionExpectation<T> Expect<T>(IEnumerable<T> actual)
        => new(actual);

    /// <summary>Create an expectation about a <see cref="IEnumerable{T}"/> of <see cref="string"/> subject</summary>
    public static CollectionExpectation<string> Expect(IEnumerable<string> actual)
        => new(actual);
}

[DebuggerNonUserCode]
public class CollectionExpectation<T>(IEnumerable<T> actual) : Expectation<IEnumerable<T>>(actual) { }

[DebuggerNonUserCode]
public static class CollectionExpectationExtensions
{
    /// <summary>Compose assertions about the <see cref="IEnumerable{T}"/> subject</summary>
    public static StringCollectionAssertions To(this CollectionExpectation<string> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the <see cref="IEnumerable{T}"/> of <see cref="string"/> subject</summary>
    public static GenericCollectionAssertions<T> To<T>(this CollectionExpectation<T> expectation)
        => expectation.Subject.Should();
}
