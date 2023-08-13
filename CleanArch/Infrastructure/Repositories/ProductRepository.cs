using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    // ریپازیتوری های داخل دامین اینجا ایمپلیمنت میشن 
    public class ProductRepository : IProductRepository
    {
        private DataContext _context;
        public ProductRepository(DataContext datacontext)
        {
            _context = datacontext;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Product> GetById(long id)
        {
            var result = _context.Products.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(result);
        }   

        public void Add(Product product)
        {
            _context.Products.Add(product);
            SaveChanges();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            SaveChanges();
        }

        public void Update(Product product)
        {
            //var OldProduct = GetById(product.Id);
            //Remove(OldProduct);
            //Add(product);
            SaveChanges();
        }

        public bool IsProductExist(long id)
        {
            bool IsProductExist = _context.Products.Any(p => p.Id == id);
            return IsProductExist;
        }

        public async Task SaveChanges()
        {
            // 
        }
    }
}