using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface ITopicService
    {
        Task CreateAsync(Topic model);
        Task<(List<Topic>, int)> GetAllAsync(int? offset, int? limit);
        Task<Topic> GetByIdAsync(Guid id);
        Task UpdateAsync(Topic model);
        Task DeleteAsync(Guid id);
    }
}
