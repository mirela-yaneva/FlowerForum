using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateAsync(User model);
        Task<PaginationResult<User>> GetAllAsync(int? pageNumber, int? pageSize);
        Task<User> GetByIdAsync(Guid id);
        Task UpdateAsync(User model);
        Task DeleteAsync(Guid id);
    }
}
