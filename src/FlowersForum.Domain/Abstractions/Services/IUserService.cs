using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateAsync(User model);
        Task<PaginationResult<User>> GetAllAsync(int? offset, int? limit);
        Task<User> GetByIdAsync(Guid id);
        Task UpdateAsync(User model);
        Task DeleteAsync(Guid id);
        Task<LoginResponse> LoginAsync(string userName, string password);
    }
}
