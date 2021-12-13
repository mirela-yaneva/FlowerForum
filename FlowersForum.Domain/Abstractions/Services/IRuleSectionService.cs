using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IRuleSectionService
    {
        Task CreateAsync(RuleSectionModel model);
        Task<List<RuleSectionModel>> GetAllAsync(int? offset, int? limit);
        Task<RuleSectionModel> GetByIdAsync(Guid id);
        Task UpdateAsync(RuleSectionModel model);
        Task DeleteAsync(Guid id);
    }
}
