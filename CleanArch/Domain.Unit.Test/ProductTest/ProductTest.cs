using Domain.Exception;
using Domain.Unit.Test.Builder;
using FluentAssertions;
using Xunit;

namespace Domain.Unit.Test.ProductTest;

public class ProductTest
{
    private ProductBuilder _productBuilder; 
    public ProductTest()
    {
        _productBuilder = new ProductBuilder();
    }

     
    [Fact]
    public void Constructor_Should_Create_Product_When_Data_isOk()
    {

        // arrange
        _productBuilder.SetTitle("test").SetMoney(10000);

        // act 
        var product = _productBuilder.Build();


        // asserts
        product.Title.Should().Be("test");  
    }

    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyException_When_Data_isNull()
    {
        // act 
        var action = new Action(() =>
        {
            _productBuilder.SetTitle("").Build();
        });


        // asserts
        action.Should().Throw<NotImplementedException>().WithMessage("title is null");
    }

}

