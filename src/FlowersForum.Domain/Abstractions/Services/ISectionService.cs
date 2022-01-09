using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface ISectionService
    {
        Task CreateAsync(Section model);
        Task<PaginationResult<Section>> GetAllAsync(int? offset, int? limit);
        Task<Section> GetByIdAsync(Guid id);
        Task UpdateAsync(Section model);
        Task DeleteAsync(Guid id);
    }
}
