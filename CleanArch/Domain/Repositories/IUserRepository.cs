using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        Task<User> GetById(long id);
        void Add(User user);
        void Update(User user);
        void Remove(User user);
        Task SaveChanges();
    }
}
