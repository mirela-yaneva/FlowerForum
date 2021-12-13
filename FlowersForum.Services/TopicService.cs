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

        public Task CreateAsync(TopicModel model)
        {
            return _topicRepository.CreateAsync(model);
        }

        public  Task<List<TopicModel>> GetAllAsync(int? offset, int? limit)
        {
            return _topicRepository.GetAllAsync(offset, limit);
        }

        public Task<TopicModel> GetByIdAsync(Guid id)
        {
            return _topicRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(TopicModel model)
        {
            return _topicRepository.UpdateAsync(model);
        }

        public Task DeleteAsync(Guid id)
        {
            return _topicRepository.DeleteAsync(id);
        }
    }
}
