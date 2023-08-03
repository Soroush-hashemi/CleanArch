using Domain.Unit.Test.Builder;
using FluentAssertions;
using System;
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
        product.Price.Value.Should().Be(10000);
    }

    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyException_When_Title_isNull()
    {
        // act 
        var action = new Action(() =>
        {
            _productBuilder.SetTitle("").Build();
        });

        // asserts
        action.Should().Throw<NotImplementedException>().WithMessage("title is null");
    }


    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyException_When_Price_isNull()
    {
        // act 
        var action = new Action(() =>
        {
            _productBuilder.SetMoney(0).Build();
        });

        // asserts
        action.Should().Throw<NotImplementedException>().WithMessage("price is Not Valid");
    }

    [Fact]
    public void Edit_Should_Update_Product_when_Data_IsOk()
    {
        // arrange
        var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();

        // act 
        product.Edit("TestTwo", new Base.Money(10000));

        // asserts
        product.Title.Should().Be("TestTwo");
        product.Price.Value.Should().Be(10000);
    }

    [Fact]
    public void Edit_Should_Throw_NullOrEmptyException_when_Title_IsNull()
    {
        // act 
        var action = new Action(() =>
        {
            _productBuilder.SetTitle("").Build();
        });

        // asserts
        action.Should().Throw<NotImplementedException>().WithMessage("title is null");
    }

    [Fact]
    public void Edit_Should_Throw_NullOrEmptyException_when_Price_IsZero()
    {
        // act 
        var action = new Action(() =>
        {
            _productBuilder.SetMoney(0).Build();
        });

        // asserts
        action.Should().Throw<NotImplementedException>().WithMessage("price is Not Valid");
    }

    [Fact]
    public void AddImage_Should_Add_Image_To_Product()
    {
        var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();

        product.AddImage("Test.png");

        product.Images.Should().HaveCount(1);
    }

    [Fact]
    public void AddImage_Should_Throw_NullOrEmptyException_When_ImageName_IsNull()
    {
        // act 
        var action = new Action(() =>
        {
            var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();
            product.AddImage("");
        });

        // asserts
        action.Should().Throw<NotImplementedException>().WithMessage("ImageName Is Null");
    }

    [Fact]
    public void RemoveImage_Should_Remove_Image_When_We_Call_It()
    {
        var product = _productBuilder.SetTitle("Test").SetMoney(10000).Build();

        product.AddImage("Testimage.png");

        product.RemoveImage(0);

        product.Images.Should().HaveCount(0);
    }
}
