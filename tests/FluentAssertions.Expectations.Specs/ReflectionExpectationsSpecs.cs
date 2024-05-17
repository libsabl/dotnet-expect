using FluentAssertions.Reflection;
using FluentAssertions.Types;
using System.Diagnostics;
using System.Reflection;

namespace FluentAssertions.Expectations.Specs;

public class ReflectionExpectationsSpecs
{
    [Fact]
    public void Expect_To_Returns_AssemblyAssertions()
    {
        Assembly assemblyValue = typeof(string).Assembly;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(assemblyValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<AssemblyAssertions>();
        assertions.DefineType("System", "String");

        // Verify API equivalency
        var shouldResult = assemblyValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_TypeAssertions()
    {
        Type typeValue = typeof(string);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(typeValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<TypeAssertions>();
        assertions.Implement(typeof(IEnumerable<char>));

        // Verify API equivalency
        var shouldResult = typeValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_TypeSelectorAssertions()
    {
        var typeSelectorValue = new TypeSelector([
            typeof(string),
            typeof(int),
            typeof(Guid)
        ]);

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(typeSelectorValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<TypeSelectorAssertions>();
        assertions.BeInNamespace("System");

        // Verify API equivalency
        var shouldResult = typeSelectorValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_ConstructorInfoAssertions()
    {
        ConstructorInfo constructorInfoValue = typeof(object).GetConstructor([])!;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(constructorInfoValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<ConstructorInfoAssertions>();
        assertions.NotBeDecoratedWith<DebuggerHiddenAttribute>();

        // Verify API equivalency
        var shouldResult = constructorInfoValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_MethodInfoAssertions()
    {
        MethodInfo methodInfoValue = typeof(string).GetMethod("ToLowerInvariant")!;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(methodInfoValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<MethodInfoAssertions>();
        assertions.Return(typeof(string));

        // Verify API equivalency
        var shouldResult = methodInfoValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_MethodInfoSelectorAssertions()
    {
        var methodInfoSelectorValue = new MethodInfoSelector([
            typeof(List<int>),
            typeof(int[])
        ]).ThatArePublicOrInternal;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(methodInfoSelectorValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<MethodInfoSelectorAssertions>();
        assertions.NotBeAsync();

        // Verify API equivalency
        var shouldResult = methodInfoSelectorValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, subjectMemberName: "SubjectMethods");
    }

    [Fact]
    public void Expect_To_Returns_PropertyInfoAssertions()
    {
        PropertyInfo propertyInfoValue = typeof(string).GetProperty("Length")!;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(propertyInfoValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<PropertyInfoAssertions>();
        assertions.Return(typeof(int));

        // Verify API equivalency
        var shouldResult = propertyInfoValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult);
    }

    [Fact]
    public void Expect_To_Returns_PropertyInfoSelectorAssertions()
    {
        var anon1 = new { a = 1 };
        var anon2 = new { b = 2 };

        var propertyInfoSelectorValue = new PropertyInfoSelector([
            anon1.GetType(),
            anon2.GetType()
        ]).ThatArePublicOrInternal;

        // Act: We are testing Expect(...).To() itself
        var assertions = Expect(propertyInfoSelectorValue).To();

        // Assert
        Expect(assertions).To().BeAssignableTo<PropertyInfoSelectorAssertions>();
        assertions.NotBeWritable();

        // Verify API equivalency
        var shouldResult = propertyInfoSelectorValue.Should();
        Expect(assertions).To().BeSameAssertionAs(shouldResult, subjectMemberName: "SubjectProperties");
    }

}
