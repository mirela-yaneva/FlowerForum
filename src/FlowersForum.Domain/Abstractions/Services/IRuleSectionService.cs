using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IRuleSectionService
    {
        Task CreateAsync(RuleSection model);
        Task<PaginationResult<RuleSection>> GetAllAsync(int? offset, int? limit);
        Task<RuleSection> GetByIdAsync(Guid id);
        Task UpdateAsync(RuleSection model);
        Task DeleteAsync(Guid id);
    }
}
