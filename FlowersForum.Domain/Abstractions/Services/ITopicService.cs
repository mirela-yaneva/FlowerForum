using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface ITopicService
    {
        Task CreateAsync(TopicModel model);
        Task<List<TopicModel>> GetAllAsync(int? offset, int? limit);
        Task<TopicModel> GetByIdAsync(Guid id);
        Task UpdateAsync(TopicModel model);
        Task DeleteAsync(Guid id);
    }
}
