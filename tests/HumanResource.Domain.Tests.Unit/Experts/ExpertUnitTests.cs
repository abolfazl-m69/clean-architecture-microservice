using FluentAssertions;
using Xunit;

namespace HumanResource.Domain.Tests.Unit.Experts;

public class ExpertUnitTests
{
    private readonly ExpertUnitTestBuilder _productUnitTestBuilder;

    public ExpertUnitTests()
    {
        _productUnitTestBuilder = new ExpertUnitTestBuilder();
    }

    [Fact]
    public void Concrete_Properly()
    {
        var product = _productUnitTestBuilder.Build();

        product.Id.Should().Be(_productUnitTestBuilder.Id);
        product.FirstName.Should().Be(_productUnitTestBuilder.FirstName);
        product.LastName.Should().Be(_productUnitTestBuilder.LastName);
        product.CellPhone.Should().Be(_productUnitTestBuilder.CellPhone);
        product.PictureId.Should().Be(_productUnitTestBuilder.PictureId);
        product.PictureUri.Should().Be(_productUnitTestBuilder.PictureUri);
    }
}