using Application.DTOs.Products;
using Domain.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Unit.Test.Builder
{
    public class ProductServiceBuilder
    {
        public AddProductDto CreateAddProductDto(string title, int price)
        {
            return new AddProductDto()
            {
                Price = price,
                Title = title
            };
        }

        public EditProductDto EditProductDto(long ProductId,string title, int price)
        {
            return new EditProductDto()
            {
                Id = ProductId,
                Price = price,
                Title = title
            };
        }

        public ProductDto ProductDto(long ProductId, string title, int price)
        {
            return new ProductDto()
            {
                Id = ProductId,
                Price = price,
                Title = title
            };
        }
    }
}
