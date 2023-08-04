using Domain.Unit.Test.Builder;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Unit.Test.ProductAgg;

public class ProductTest
{
    private ProductBuilder _productBuilder;
    public ProductTest()
    {
        _productBuilder = new ProductBuilder();
    }

    [Fact]
    public void Constructor_Should_Create_Product_When_Data_Was_Ok()
    {
        _productBuilder.SetTitle("test").SetMoney(10000);

        var product = _productBuilder.Build();

        product.Title.Should().Be("test");
        product.Price.Value.Should().Be(10000);
    }

    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyException_When_Title_Was_Null()
    {
        var action = new Action(() =>
        {
            _productBuilder.SetTitle("").Build();
        });

        action.Should().Throw<NotImplementedException>().WithMessage("title is null");
    }


    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyException_When_Price_Was_Null()
    {
        var action = new Action(() =>
        {
            _productBuilder.SetMoney(0).Build();
        });

        action.Should().Throw<NotImplementedException>().WithMessage("price is not valid");
    }

    [Fact]
    public void Edit_Should_Update_Product_when_Data_IsOk()
    {
        var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();

        product.Edit("TestTwo", new Base.Money(10000));

        product.Title.Should().Be("TestTwo");
        product.Price.Value.Should().Be(10000);
    }

    [Fact]
    public void Edit_Should_Throw_NullOrEmptyException_when_Title_Was_Null()
    {
        var action = new Action(() =>
        {
            _productBuilder.SetTitle("").Build();
        });

        action.Should().Throw<NotImplementedException>().WithMessage("title is null");
    }

    [Fact]
    public void Edit_Should_Throw_NullOrEmptyException_when_Price_Was_Zero()
    {
        var action = new Action(() =>
        {
            _productBuilder.SetMoney(0).Build();
        });

        action.Should().Throw<NotImplementedException>().WithMessage("price is not valid");
    }

    [Fact]
    public void AddImage_Should_Add_Image_To_Product()
    {
        var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();

        product.AddImage("Test.png");

        product.Images.Should().HaveCount(1);
    }

    [Fact]
    public void AddImage_Should_Throw_NullOrEmptyException_When_ImageName_Was_Null()
    {
        var action = new Action(() =>
        {
            var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();
            product.AddImage("");
        });

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

    [Fact]
    public void RemoveImage_Should_Throw_NullOrEmptyException_When_Image_Was_Null()
    {
        var action = new Action(() =>
        {
            var product = _productBuilder.SetTitle("TestOne").SetMoney(1000000).Build();
            product.RemoveImage(0);
        });

        action.Should().Throw<NotImplementedException>().WithMessage("is not valid");
    }
}
