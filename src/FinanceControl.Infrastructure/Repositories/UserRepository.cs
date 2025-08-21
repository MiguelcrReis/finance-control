using FinanceControl.Application.Contracts;
using FinanceControl.Domain.Entities;
using FinanceControl.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanceControlDbContext _db;

        public UserRepository(FinanceControlDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByIdAsync(Guid id) =>
            await _db.Users.FindAsync(id);

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _db.Users.ToListAsync();

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }
    }
}
