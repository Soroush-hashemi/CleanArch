
using Domain;
using Domain.Repositories;
using Infrastructure.Persistence.Ef;

namespace Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public async Task<User> GetById(long id)
        {
            var result = _context.Users.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(result);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Remove(User user)
        {
            _context.Remove(user);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
