# FluentAssertions.Expect

Implementation of `expect(...).to` test assertion pattern for dotnet. Implemented as a thin wrapper over [FluentAssertions](https://github.com/fluentassertions/fluentassertions).

### Naming and conventions

This package is not authored by the FluentAssertions team, but is structured according to FluentAssertions project conventions so that it could be easily adopted by that project if they so desired at some point in the future.  

## Summary
 
Replaces `expression.Should()` extension syntax with `Expect(expression).To()` function call syntax
 - which avoids all the `Should()` extensions methods
 - while preserving the entire fluent syntax and API for assertions themselves


### Background

[FluentAssertions](https://github.com/fluentassertions/fluentassertions) provides a mature assertions library for testing .NET projects. 

FluentAssertions' root `value.Should()...` pattern requires [defining extension methods](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/AssertionExtensions.cs) on numerous types, including `System.Object` itself. 

Many developers find this pattern intrusive. When they are writing tests, they do not want to see test framework extension methods present in the member listing on every possible expression.

And yet, the vast majority of FluentAssertions' actual API does not depend on the root `Should(...)` extension methods. Rather, the substance of the the actual fluent assertions are defined on the types which are _returned_ from the overloads of `Should()`, such as [`ObjectAssertions`](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/Primitives/ObjectAssertions.cs) or [`NullableBooleanAssertions`](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/Primitives/NullableBooleanAssertions.cs).

This library provides a simple alternative: replacing the `Should()` extension methods with a global `Expect` function, chained with a method `To()`. `Expect` is not an extension method. Calling `Expect(...).To()` is therefore an explicit opt-in to switch from a general acting context to an asserting context. Visually, it also causes the vast majority of assertion lines to begin with the word `Expect`, providing additional visual cues about which parts of a test method constitute the actual assertions.

The return value of `Expect(value).To()` is identical to the return value of `value.Should()` on the same value, so the bulk of the API implemented in FluentAssertions is automatically available.

### Opinions

Calling FluentAssertions' extension based syntax "intrusive" is an opinion, a matter of taste. This library does not seek to sway anyone's opinion, nor to criticize the design of FluentAssertions. It simply provides an easy drop-in alternative for code authors who appreciate features of FluentAssertions but dislike the extension syntax in their own totally subjective opinion. If you or your team prefers the extension syntax, just ignore this library! All actual assertions APIs remain in FluentAssertions itself, even when using this library.

## Docs

The goal here is that almost no docs are needed. For all assertion APIs, see the [FluentAssertion docs](https://fluentassertions.com/). When you are reading those docs, just mentally replace `[expression].Should()` with `Expect([expression]).To()`. 

For the handful of other top-level extension methods provided by FluentAssertions, such as `Invoking` or `Monitor`, see [details below](#replacements). 

### Migrating from FluentAssertions .Should() syntax
 
1. Update imports
 
    > `-` ~~`using FluentAssertions`~~<br/>
    > `+` `using FluentAssertions.Expectations`<br/>
    > `+` `using FluentAssertions.Expectations.Expectation`

2. Replace Should with Expect..To

    > `-` ~~`expression.Should()...`~~<br/>
    > `+` `Expect(expression).To()...`

3. Replace other extensions as described [below](#replacements)

    > `-` ~~`expression.Invoking().Should()..`~~<br/>
    > `+` *see [Replacements](#replacements)*


   
### Replacements

|Verb|Extensions Syntax|Expectations Syntax|
|-|-|-|
|Should|`expression.Should()`|`Expect(expression).To()`|
|Invoking|`expression.Invoking(action).Should()`|`Expect().Invoking(expression, action).To()`|
|Awaiting|`expression.Awaiting(action).Should()`|`Expect().Awaiting(expression, action).To()`|
|ExecutionTimeOf|`expression.ExecutionTimeOf(action).Should()`|`Expect().ExecutionTimeOf(expression, action).To()`|
|ExecutionTime|`action.ExecutionTime().Should()`|`Expect().ExecutionTime(action).To()`|
|Enumerating|`func.Enumerating().Should()`|`Expect().Enumerating(func).To()`|
|Monitor|`using var monitoredSubject = subject.Monitor();`<br/>`monitoredSubject.Should().Raise(...);`|`using var monitoredSubject = Expect().Monitor(subject);`<br/>`Expect(monitoredSubject).To().Raise(...);`|
|As|`value.As<TTarget>().Should()`|`as` Language keyword: `Expect(value as TTarget).To()`|

### Mechanics

#### Don't import `FluentAssertions`
The `Should()` extension methods, along with several others, are implemented by FluentAssertions in the root `FluentAssertions` namespace. To remove these [intrusive](#opinions) extension methods, your test code must **not** import the `FluentAssertions` namespace itself. 

#### Do import `FluentAssertions.Expectations`

Instead, import the `FluentAssertions.Expectations` namespace. This namespace includes all the `To()` extensions. It also includes pass-through replacements for some other extension methods that are defined in the `FluentAssertions` namespace, to preserve all other FluentAssertions APIs.

#### Do static import `FluentAssertions.Expectations.Expectation`
 
All overloads of the static `Expect` method are defined on the static class `FluentAssertions.Expectations.Expectation`. If you import this class statically as shown in the examples [above](#migrating-from-fluentassertions-should-syntax), then your code can use the `Expect` function directly.

## Example

Assuming you have [updated your using statements](#migrating-from-fluentassertions-should-syntax), you can simply replace any instance of `[expression].Should()` with `Expect([expression]).To()`.

Replacements for other extensions like `Invoking` and `ExecutionTime` can be chained to a call to `Expect()` with no arguments:

```cs
Expect().Invoking(subject, action).To()...
Expect().Awaiting(subject, action).To()...
Expect().ExecutionTime(() => ... ).To()...
```

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
someObject.Should().BeOfType<Exception>().Which.Message.Should().Be("Other Message");
xDocument.Should().HaveElement("child").Which.Should().BeOfType<XElement>().And.HaveAttribute("attr", "1");

Action someAction = () => Thread.Sleep(100);
someAction.ExecutionTime().Should().BeLessThanOrEqualTo(200.Milliseconds());
```

#### After

```cs
using static FluentAssertions.Expectations;
// Note the static keyword. Expectation is a static class which provides the static method Expect()
using static FluentAssertions.Expectations.Expectation;
 
string actual = "ABCDEFGHI";
Expect(actual).To().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);

IEnumerable<int> numbers = new[] { 1, 2, 3 };
Expect(numbers).To().OnlyContain(n => n > 0);
Expect(numbers).To().HaveCount(4, "because we thought we put four items in the collection");

Expect(dictionary).To().ContainValue(myClass).Which.SomeProperty.Should().BeGreaterThan(0);
Expect(someObject).To().BeOfType<Exception>().Which.Message.Should().Be("Other Message");
Expect(xDocument).To().HaveElement("child").Which.Should().BeOfType<XElement>().And.HaveAttribute("attr", "1");

Action someAction = () => Thread.Sleep(100);
Expect().ExecutionTime(someAction).To().BeLessThanOrEqualTo(200.Milliseconds());
```