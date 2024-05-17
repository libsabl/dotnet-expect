$types = 'int', 'uint', 'decimal', 'byte', 'sbyte', 'short', 'ushort', 'long', 'ulong', 'float', 'double'

$types | ForEach-Object {
@"
    /// <summary>Create an expectation about a <see cref="$_"/> subject</summary>
    public static Expectation<$_> Expect($_ actual) => new(actual);

    /// <summary>Create an expectation about a nullable <see cref="$_"/> subject</summary>
    public static Expectation<$_`?> Expect($_`? actual) => new(actual);

"@
}
 
$types | ForEach-Object {
@"
    /// <summary>Compose assertions about the <see cref="$_"/> subject</summary>
    public static NumericAssertions<$_> To(this Expectation<$_> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="$_"/> subject</summary>
    public static NullableNumericAssertions<$_> To(this Expectation<$_`?> expectation)
        => expectation.Subject.Should();

"@
}

$line = 529
$types | ForEach-Object {
"    * $_  : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L$line"
$line += 10
"    * $_`? : https://github.com/fluentassertions/fluentassertions/blob/6.12.0/Src/FluentAssertions/AssertionExtensions.cs#L$line"
$line += 10
}
  
$types | ForEach-Object {
$varName = $_ + 'Value'
@"
[Fact]
public void Expect_To_Returns_NumericAssertions_$_()
{
    $_ $varName = 232;

    // Act: We are testing Expect(...).To() itself
    var assertions = Expect($varName).To();

    // Assert
    Expect(assertions).To().BeAssignableTo<NumericAssertions<$_>>();
    assertions.Be(232);

    // Verify API equivalency
    var shouldResult = $varName.Should();
    Expect(assertions).To().BeSameAssertionAs(shouldResult);
}

[Fact]
public void Expect_To_Returns_NullableNumericAssertions_$_()
{
    $_`? $varName = 232;

    // Act: We are testing Expect(...).To() itself
    var assertions = Expect($varName).To();

    // Assert
    Expect(assertions).To().BeAssignableTo<NullableNumericAssertions<$_>>();
    assertions.Be(232);

    // Verify API equivalency
    var shouldResult = $varName.Should();
    Expect(assertions).To().BeSameAssertionAs(shouldResult);
}

"@
}