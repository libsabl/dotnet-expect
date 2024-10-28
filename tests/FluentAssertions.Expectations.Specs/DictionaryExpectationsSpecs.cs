using FluentAssertions.Collections;
using System.Collections;

namespace FluentAssertions.Expectations.Specs;

public class DictionaryExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_GenericDictionaryAssertions_idct()
    {
        IDictionary<string, int> dctValue = new Dictionary<string, int> {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
        };

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(dctValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<
            GenericDictionaryAssertions<
                IDictionary<string, int>,
                string,
                int
            >
        >();

        assertions.Contain("a", 1)
            .And.Contain("b", 2)
            .And.Contain("c", 3);

        // Verify API equivalency
        var shouldResult = dctValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }


    [Fact]
    public void Expect_To_Returns_GenericDictionaryAssertions_ienum()
    {
        KeyValuePair<string, int>[] kpValue = [
            new("a", 1),
            new("b", 2),
            new("c", 3),
        ];

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(kpValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<
            GenericDictionaryAssertions<
                IEnumerable<KeyValuePair<string, int>>,
                string,
                int
            >
        >();

        assertions.Contain("a", 1)
            .And.Contain("b", 2)
            .And.Contain("c", 3);

        // Verify API equivalency
        var shouldResult = kpValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_GenericDictionaryAssertions_tcollection()
    {
        MyKvCollection tCollectionValue = new() {
            { "a", 1 },
            { "b", 2 },
            { "c", 3 },
        };

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(tCollectionValue).To<MyKvCollection, string, int>();

        // Assert
        Expect(assertions).To().BeOfType<
            GenericDictionaryAssertions<
                MyKvCollection,
                string,
                int
            >
        >();

        assertions.Contain("a", 1)
            .And.Contain("b", 2)
            .And.Contain("c", 3);

        // Subject of this assertion retains the original specific type
        Expect(assertions.Subject.TotalKeyLength).To().Be(3);

        // Verify API equivalency
        var shouldResult = tCollectionValue.Should<MyKvCollection, string, int>();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }
}

internal class MyKvCollection : IDisposable, IEnumerable<KeyValuePair<string, int>>
{
    private readonly List<KeyValuePair<string, int>> _items = [];

    public void Add(string key, int value) => _items.Add(new(key, value));

    public int TotalKeyLength => _items.Sum(kv => kv.Key.Length);

    public void Dispose() { }

    public IEnumerator<KeyValuePair<string, int>> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}
