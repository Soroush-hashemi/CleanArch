using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    // ریپازیتوری های داخل دامین اینجا ایمپلیمنت میشن 
    public class ProductRepository : IProductRepository
    {
        private DataContext _datacontext;
        public ProductRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<Product> GetAll()
        {
            return _datacontext.Products.ToList();
        }

        public Product GetById(long id)
        {
            return _datacontext.Products.FirstOrDefault(p => p.Id == id);
        }   

        public void Add(Product product)
        {
            _datacontext.Products.Add(product);
            Save();
        }

        public void Remove(Product product)
        {
            _datacontext.Products.Remove(product);
            Save();
        }

        public void Update(Product product)
        {
            var OldProduct = GetById(product.Id);
            Remove(OldProduct);
            Add(product);
            Save();
        }

        public bool IsProductExist(long id)
        {
            bool IsProductExist = _datacontext.Products.Any(p => p.Id == id);
            return IsProductExist;
        }

        public void Save()
        {
            //
        }
    }
}