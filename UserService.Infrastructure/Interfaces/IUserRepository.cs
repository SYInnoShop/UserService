using UserService.Domain.Entities;

namespace UserService.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<bool> AnyUsersAsync();
    Task<User?> GetByEmailAsync(string email);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}