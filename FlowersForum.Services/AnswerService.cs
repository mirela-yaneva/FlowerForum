using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public Task CreateAsync(AnswerModel model)
        {
            return _answerRepository.CreateAsync(model);
        }

        public Task<List<AnswerModel>> GetAllAsync(int? offset, int? limit)
        {
            return  _answerRepository.GetAllAsync(offset, limit);
        }

        public Task<AnswerModel> GetByIdAsync(Guid id)
        {
            return _answerRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(AnswerModel model)
        {
            return _answerRepository.UpdateAsync(model);
        }

        public Task DeleteAsync(Guid id)
        {
            return _answerRepository.DeleteAsync(id);
        }
    }
}
