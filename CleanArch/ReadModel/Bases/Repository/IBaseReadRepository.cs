namespace ReadModel.Bases.Repository
{
    public interface IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long Id);
        Task<TEntity> GetById(long Id);
        Task<List<TEntity>> GetAll();
    }
}