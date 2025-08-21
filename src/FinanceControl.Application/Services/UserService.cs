using FinanceControl.Application.Contracts;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.GetAllAsync();

        public async Task<User?> GetByIdAsync(Guid id) => await _userRepository.GetByIdAsync(id);

        public async Task<User> CreateAsync(string name, string email)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task UpdateAsync(User user) => await _userRepository.UpdateAsync(user);

        public async Task DeleteAsync(Guid id) => await _userRepository.DeleteAsync(id);
    }
}
