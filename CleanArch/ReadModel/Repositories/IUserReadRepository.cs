using ReadModel.Bases.Repository;
using ReadModel.Entities.UserAgg;

namespace ReadModel.Repositories;
public interface IUserReadRepository : IBaseReadRepository<UserReadModel>
{
    Task<UserReadModel> GetByEmail(string email);
}