using Application.Unit.Test.Builder;
using Application.UseCases;
using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Application.Unit.Test.UseCases
{
    public class ProductServicesTest
    {
        private readonly ProductServiceBuilder _builder;
        private readonly ProductServices _ProductServices;
        private readonly IProductRepository _repository;
        public ProductServicesTest()
        {
            _builder = new ProductServiceBuilder();
            _repository = Substitute.For<IProductRepository>();
            _ProductServices = new(_repository);
        }

        [Fact]
        public void AddProduct_Should_Add_Product()
        {
            var command = _builder.CreateAddProductDto("test", 10000);

            _ProductServices.AddProduct(command);

            _repository.Received(1).Save();
        }

        [Fact]
        public void EditProduct_Should_Edit_Product()
        {
            _repository.GetById(Arg.Any<long>()).Returns(new Product("Test" ,  new Money(1000)));
            var command = _builder.EditProductDto(1, "testTwo", 11000);

            _ProductServices.EditProduct(command);

            _repository.Received(1).Save();
        }

        [Fact]
        public void GetProductById_Should_Get_Product_By_Id()
        {
            _repository.GetById(Arg.Any<long>()).Returns(new Product("Test", new Money(1000)));

            var product = _ProductServices.GetProductById(1);

            product.Should().Be(product);
        }

        [Fact]
        public void GetProducts_Should_Get_All_Product()
        {
            _repository.GetAll().Returns(new List<Product>()
            {
                new Product("TestOne", new Money(1000)),
                new Product("TestTwo", new Money(1100)),
            });

            var product = _ProductServices.GetProducts();
            product.Should().HaveCount(2);
        }
    }
}