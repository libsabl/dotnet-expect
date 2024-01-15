# Sabl.Expect

Implementation of `expect(...).to` test assertion pattern for dotnet. Implemented as a thin wrapper over [FluentAssertions](https://github.com/fluentassertions/fluentassertions).

### Naming and conventions

This package is not authored by the FluentAssertions team, but is structured according to FluentAssertions project conventions so that it could be easily adopted by that project if they so desired at some point in the future. Likewise, the published package name is `Sabl.Expect` to avoid any ambiguity in authorship and support, but the root namespace is `FluentAssertions.Expectations` for best compatibility in source code.

## Summary
 
Replaces `expression.Should()` extension syntax with `Expect(expression).To()` function call syntax
 - which avoids all the `Should()` extensions methods
 - while preserving the entire fluent syntax and API for assertions themselves

### Background

[FluentAssertions](https://github.com/fluentassertions/fluentassertions) provides a mature assertions library for testing .NET projects. 

FluentAssertions' root `value.Should()...` pattern requires [defining extension methods](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/AssertionExtensions.cs) on numerous types, including `System.Object` itself. 

Many developers find this pattern intrusive. When they are writing tests, they do not want to see test framework extension methods present in the member listing on every possible expression.

And yet, the vast majority of FluentAssertions' actual API does not depend on the root `Should(...)` extension methods. Rather, the substance of the the actual fluent assertions are defined on the types which are _returned_ from the overloads of `Should()`, such as [`ObjectAssertions`](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/Primitives/ObjectAssertions.cs) or [`NullableBooleanAssertions`](https://github.com/fluentassertions/fluentassertions/blob/develop/Src/FluentAssertions/Primitives/NullableBooleanAssertions.cs).

This library provides a simple alternative: replacing the `Should()` extension methods with a global `Expect` function, chained with a method `To()`. `Expect` is not an extension method. Calling `Expect(...).To()` is therefore an explicit opt-in to switch from a general acting context to an asserting context. Visually, it also causes the vast majority of assertion lines to begin with the word `Expect`.

To actual return value of `Expect(value).To()` is identical to the return value of `value.Should()` on the same value.

### Opinions

Calling FluentAssertions' extension based syntax "intrusive" is an opinion, a matter of taste. This library does not seek to sway anyone's opinion, nor to criticize the design of FluentAssertions. It simply provides an easy drop-in alternative for code authors who appreciate FluentAssertions but dislike the extension syntax in their own totally subjective opinion. If you or your team prefers the extension syntax, just ignore this library! All actual assertions APIs remain in FluentAssertions itself, even when using this library.
