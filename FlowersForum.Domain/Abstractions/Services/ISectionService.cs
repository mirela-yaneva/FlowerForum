using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface ISectionService
    {
        Task CreateAsync(SectionModel model);
        Task<List<SectionModel>> GetAllAsync(int? offset, int? limit);
        Task<SectionModel> GetByIdAsync(Guid id);
        Task UpdateAsync(SectionModel model);
        Task DeleteAsync(Guid id);
    }
}
