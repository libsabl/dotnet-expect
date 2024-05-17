using System.Collections;

namespace FluentAssertions.Expectations.Specs;

public class AndWhichExtensionsSpecs
{
    [Fact]
    public void As_Extracts_SubjectPropValue()
    {
        List<int> list = [1, 2, 3];
        IEnumerable maybeList = list;

        // Act: 
        Expect(maybeList).To().BeAssignableTo<IEnumerable<int>>().As(out var enumerable);

        // Assert: Returned correct subject
        Expect(enumerable).To().BeSameAs(list);

        // Verify API equivalence
        var subjectValue = maybeList.Should().BeAssignableTo<IEnumerable<int>>().Subject;
        Expect(enumerable).To().BeSameAs(subjectValue);
    }
}
