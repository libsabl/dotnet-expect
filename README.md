# FluentAssertions.Expect

[![codecov](https://codecov.io/github/libsabl/fluentassertions.expect/branch/main/graph/badge.svg?token=Gkk14y95yf)](https://codecov.io/github/libsabl/fluentassertions.expect)  ![tests](https://github.com/libsabl/fluentassertions.expect/actions/workflows/dotnet-test.yml/badge.svg?branch=main)

FluentAssertions.Expect provides the `expect(...).to` test assertion pattern for dotnet, implemented as a thin wrapper over [FluentAssertions](https://github.com/fluentassertions/fluentassertions). This provides a syntax familiar in other languages such as Jest or Chai for Node, while also eliminating the [intrusive](#opinions) extension methods that FluentAssertions defines in the base `FluentAssertions` namespace.

- [Summary](#summary) 
- [Docs](#docs)
- [Examples](#example)

## TLDR

```cs
// before
someValue.Should().BeGreaterThan(12);

// after
Expect(someValue).To().BeGreaterThan(12);
```

Other [replacements](#replacements) and [examples](#example) below.

## Summary
 
Replaces `expression.Should()` extension syntax with `Expect(expression).To()` function call syntax
 - which avoids all the `Should()` and other extension methods
 - while preserving the fluent syntax and API for assertions themselves

### Background

[FluentAssertions](https://github.com/fluentassertions/fluentassertions) provides a mature assertions library for testing .NET projects. 

FluentAssertions' root `value.Should()...` pattern requires [defining extension methods](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/AssertionExtensions.cs) on numerous types, including `System.Object` itself. 

Some developers find this pattern intrusive. When they are writing tests, they do not want to see test framework extension methods present in the member listing on every possible expression.

And yet, the vast majority of FluentAssertions' actual API does not depend on the root `Should(...)` extension methods. Rather, the substance of the the actual fluent assertions are defined on the types which are _returned_ from the overloads of `Should()`, such as [`ObjectAssertions`](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/Primitives/ObjectAssertions.cs) or [`NullableBooleanAssertions`](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/Primitives/NullableBooleanAssertions.cs).

This library provides a simple alternative: replacing the `Should()` extension methods with a global `Expect` function, chained with a method `To()`. `Expect` is not an extension method. Calling `Expect(...).To()` is therefore an explicit opt-in to switch from a general acting context to an asserting context. Visually, it also causes the vast majority of assertion lines to begin with the word `Expect`, providing additional visual cues about which parts of a test method constitute the actual assertions.

The return value of `Expect(value).To()` is identical to the return value of `value.Should()` on the same value, so the bulk of the API implemented in FluentAssertions is automatically available.

### Opinions

Calling FluentAssertions' extension based syntax "intrusive" is an opinion, a matter of taste. This library does not seek to sway anyone's opinion, nor to criticize the design of FluentAssertions. It simply provides an easy drop-in alternative for code authors who appreciate features of FluentAssertions but dislike the extension syntax in their own totally subjective opinion. If you or your team prefers the extension syntax, just ignore this library! All actual assertions APIs remain in FluentAssertions itself, even when using this library.

### Naming and conventions

This package is not authored by the FluentAssertions team, but is structured according to FluentAssertions project conventions so that it could be easily adopted by that project if they so desired at some point in the future.

## Docs

For all assertion APIs, see the [FluentAssertion docs](https://fluentassertions.com/). When you are reading those docs, just mentally replace `[expression].Should()` with `Expect([expression]).To()`. 

For the handful of other top-level extension methods provided by FluentAssertions, such as `Invoking` or `Monitor`, see [details below](#replacements). 

### Migrating from FluentAssertions .Should() syntax
 
1. Update imports
 
    > `-` ~~`using FluentAssertions`~~<br/>
    > `+` `using FluentAssertions.Expectations`<br/>
    > `+` `using static FluentAssertions.Expectations.Expectation`

2. Replace Should with Expect..To

    > `-` ~~`expression.Should()...`~~<br/>
    > `+` `Expect(expression).To()...`

3. Replace other extensions as described [below](#replacements)

    > `-` ~~`expression.Invoking().Should()..`~~<br/>
    > `+` *see [Replacements](#replacements)*
 
### Mechanics

#### Don't import `FluentAssertions`
The `Should()` extension methods, along with several others, are implemented by FluentAssertions in the root `FluentAssertions` namespace. To remove these [intrusive](#opinions) extension methods, your test code must **not** import the `FluentAssertions` namespace itself. 

#### Do import `FluentAssertions.Expectations`

Instead, import the `FluentAssertions.Expectations` namespace. This namespace includes all the `To()` extensions. It also includes pass-through replacements for some other extension methods that are defined in the `FluentAssertions` namespace, to preserve all other FluentAssertions APIs.

#### Do static import `FluentAssertions.Expectations.Expectation`
 
All overloads of the static `Expect` method are defined on the static class `FluentAssertions.Expectations.Expectation`. If you import this class statically as shown in the examples [above](#migrating-from-fluentassertions-should-syntax), then your code can use the `Expect` function directly.

### Replacements

|Verb|Extensions Syntax|Expectations Syntax|
|-|-|-|
|Should()|`expression.Should()`|`Expect(expression).To()`|
|Invoking()|`expression.Invoking(action).Should()`|`Expect().Invoking(expression, action).To()`|
|Awaiting()|`expression.Awaiting(action).Should()`|`Expect().Awaiting(expression, action).To()`|
|As()|`value.As<TTarget>().Should()`|`as` Language keyword: `Expect(value as TTarget).To()`|
|Which, Subject|`..BeOfType<T>().Which.Should()..`|See [Replacing chains that use Which, Subject](#replacing-chains-that-use-which-subject)|

### Replacing chains that use Which, Subject

FluentAssertions allows chaining indefinitely long sequences of cascading assertions via the `Which` and `Subject` properties of some assertion types. `Which` and `Subject` are synonyms and return the same value. These properties are present when the previous assertion implicitly extracts a different value from the original subject.

The philosophy of the Expect pattern here is to make the context switch explicit by starting a new assertion with Expect. However, a convenience method `As(out _)` allows a semantically fluid way of terminating the previous asserting by creating a new variable to hold the derived value, using the C# `out var <variable>` syntax to declare a new variable inline. See the following sections for examples.

#### Example: Extracting a different type

BeOfType&lt;T&gt; returns the same underlying value as the original subject, but statically casts it to a different type, and throws a test failure if the type cast fails. This allows making further assertions that can't be applied to the original type, but can be applied to the asserted type. In the example below, the original value is simply an `object`, but by asserting that the value is specifically an `int`, the test code can make a further assertion about the numeric value of that `int`.

FluentAssertions style chaining with `Which`:

```cs
 object objValue = someFunc();
 objValue.Should().BeOfType<int>().Which.Should().BeGreaterThan(11); 
"|<----- subject is object ----->| |<---- now subject is int ---->|"
```

Expect style extracting derived values with `As(out var _)`;

```cs
object objValue = someFunc();
Expect(objValue).To().BeOfType<int>().As(out var intValue);  // subject is object
Expect(intValue).To().BeGreaterThan(11);                     // now subject is int
```

#### Example: Extracting derived value

Other assertions for certain complex types return a descendant, parent, or other related value to the original subject. In the example below HaveElement and HaveAttribute are used to incrementally navigate an XML document, making assertions along the way.

FluentAssertions style chaining with `Which`:

```cs
XDocument myDoc = getSomeXml();
myDoc.Should().HaveElement("group")           // asserting about XDocument
    .Which.Should().HaveElement("section")    // now asserting about XElement
    .Which.Should().HaveAttribute("version")  // now asserting about another XElement
    .Which.Value.Should().Be("11");           // now asserting about XAttribute
```

Expect style extracting derived values with `As(out var _)`;

```cs
XDocument myDoc = getSomeXml();
Expect(myDoc).To().HaveElement("group").As(out var xGroup);       // asserting about XDocument
Expect(xGroup).To().HaveElement("section").As(out var xSection);  // now asserting about XElement
Expect(xSection).To().HaveAttribute("version").As(out var xAttr); // now asserting about another XElement
Expect(xAttr.Value).To().Be("11");                                // now asserting about XAttribute
```

## Example

Extended comparison using examples included in FluentAssertions docs.

#### Before

```cs
// Examples from https://fluentassertions.com
using FluentAssertions;
 
string actual = "ABCDEFGHI";
actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);

IEnumerable<int> numbers = new[] { 1, 2, 3 };
numbers.Should().OnlyContain(n => n > 0);
numbers.Should().HaveCount(4, "because we thought we put four items in the collection");

dictionary.Should().ContainValue(myClass).Which.SomeProperty.Should().BeGreaterThan(0);
```

#### After

```cs
using FluentAssertions.Expectations;
using static FluentAssertions.Expectations.Expectation;
 
string actual = "ABCDEFGHI";
Expect(actual).To().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);

IEnumerable<int> numbers = new[] { 1, 2, 3 };
Expect(numbers).To().OnlyContain(n => n > 0);
Expect(numbers).To().HaveCount(4, "because we thought we put four items in the collection");

Expect(dictionary).To().ContainValue(myClass).As(out var value);
Expect(value.SomeProperty).To().BeGreaterThan(0);
```