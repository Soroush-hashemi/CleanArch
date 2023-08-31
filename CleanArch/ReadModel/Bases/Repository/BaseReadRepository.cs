using MongoDB.Driver;
using ReadModel.Entities.ProductAgg;
using ReadModel.ValueObject;

namespace ReadModel.Bases.Repository
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
        private readonly IMongoCollection<TEntity> _collection;
        public BaseReadRepository(IMongoClient client)
        {
            var dateBase = client.GetDatabase("cleanArch");
            _collection = dateBase.GetCollection<TEntity>(typeof(TEntity).Name); // اینجا اسم انتیتی روی کالکشن گذاشته میشه
        }

        public async Task<List<TEntity>> GetAll()
        {
            var result = await _collection.FindAsync(t => true);
            return result.ToList();
        }

        public async Task<TEntity> GetById(long Id)
        {
            var result = await _collection.FindAsync(d => d.Id == Id);
            return result.FirstOrDefault();
        }

        public async Task Delete(long Id)
        {
            await _collection.DeleteOneAsync(d => d.Id == Id);
        }

        public async Task Insert(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _collection.ReplaceOneAsync(u => u.Id == entity.Id, entity);
        }
    }
}
