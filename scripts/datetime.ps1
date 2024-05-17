$types = 'DateTime', 'DateTimeOffset', 'DateOnly', 'TimeOnly', 'TimeSpan'

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
    public static $($_)Assertions To(this Expectation<$_> expectation)
        => expectation.Subject.Should();

    /// <summary>Compose assertions about the nullable <see cref="$_"/> subject</summary>
    public static Nullable$($_)Assertions To(this Expectation<$_`?> expectation)
        => expectation.Subject.Should();

"@
}


$examples = @{
  'DateTime' = 'new DateTime(1970, 01, 01, 12, 34, 56, 789)'
  'DateTimeOffset' = 'new DateTimeOffset(1970, 01, 01, 12, 34, 56, 789, TimeSpan.Zero)'
  'DateOnly' = 'new DateOnly(1970, 01, 01)'
  'TimeOnly' = 'new TimeOnly(12, 34, 56, 789)'
  'TimeSpan' = 'TimeSpan.FromMilliseconds(2309)'
}

$types | ForEach-Object {
$typeName = $_
$varName = $typeName.Substring(0,1).ToLower() + $typeName.Substring(1) + 'Value'
$ex = $examples[$typeName]

@"
[Fact]
public void Expect_To_Returns_$($typeName)Assertions()
{
    $typeName $varName = $ex;

    // Act: We are testing Expect(...).To() itself
    var assertions = Expect($varName).To();

    // Assert
    Expect(assertions).To().BeAssignableTo<$($typeName)Assertions>();
    assertions.Be($ex);

    // Verify API equivalency
    var shouldResult = $varName.Should();
    Expect(assertions).To().BeSameAssertionAs(shouldResult);
}

[Fact]
public void Expect_To_Returns_Nullable$($typeName)Assertions()
{
    $_`? $varName = $ex;

    // Act: We are testing Expect(...).To() itself
    var assertions = Expect($varName).To();

    // Assert
    Expect(assertions).To().BeAssignableTo<Nullable$($typeName)Assertions>();
    assertions.Be($ex);

    // Verify API equivalency
    var shouldResult = $varName.Should();
    Expect(assertions).To().BeSameAssertionAs(shouldResult);
}

"@
}