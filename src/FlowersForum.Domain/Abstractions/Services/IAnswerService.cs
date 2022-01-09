using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IAnswerService
    {
        Task CreateAsync(Answer model);
        Task<PaginationResult<Answer>> GetAllAsync(int? offset, int? limit);
        Task<Answer> GetByIdAsync(Guid id);
        Task UpdateAsync(Answer model);
        Task DeleteAsync(Guid id);
    }
}
