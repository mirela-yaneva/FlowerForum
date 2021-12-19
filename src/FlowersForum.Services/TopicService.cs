using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public Task CreateAsync(Topic model)
            => _topicRepository.CreateAsync(model);

        public Task<(List<Topic>, int)> GetAllAsync(int? offset, int? limit)
            => _topicRepository.GetAllAsync(offset, limit); 

        public Task<Topic> GetByIdAsync(Guid id)
        => _topicRepository.GetByIdAsync(id);

        public Task UpdateAsync(Topic model)
            => (_topicRepository.UpdateAsync(model));

        public Task DeleteAsync(Guid id)
            => (_topicRepository.DeleteAsync(id));
    }
}
