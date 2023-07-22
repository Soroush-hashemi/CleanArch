using Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductServices
    {
        void AddProduct(AddProductDto command);
        void EditProduct(EditProductDto command);
        ProductDto GetProductById(Guid productId);
        List<ProductDto> GetProducts();
    }
}
