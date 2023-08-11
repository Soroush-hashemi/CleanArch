using Application.Common.Interfaces;
using Application.DTOs.Products;
using Domain.Entities;
using Domain.Repositories;
using Domain.Base;

namespace Application.UseCases
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(AddProductDto command)
        {
            _productRepository.Add(new Product(command.Title , new Money(command.Price))); // اول به دایمن میره که بررسی بشه 
            // بعدا به ریپازیتوری میره 

            _productRepository.Save();//  در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم
        }

        public void EditProduct(EditProductDto command)
        {
            var product = _productRepository.GetById(command.Id);
            product.Edit(command.Title, new Money(command.Price));
            _productRepository.Update(product);
            // اینجا اول به دامین میدیم که قوانین مون رو بررسی بکنه ببینه رعایت شده یا نه 
            // بعدا به ریپازیتوری میدیم که برامون ادیت کنه 
            _productRepository.Save(); // در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم
        }

        public ProductDto GetProductById(long productId)
        {
            var product = _productRepository.GetById(productId);
            return new ProductDto()
            {
                Price = product.Price.Value,
                Title = product.Title,
                Id = productId
            };
        }

        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetAll().Select(product => new ProductDto()
            {
                Price = product.Price.Value,
                Title = product.Title,
                Id = product.Id
            }).ToList();
        }
    }
}
