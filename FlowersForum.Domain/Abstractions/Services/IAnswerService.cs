using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IAnswerService
    {
        Task CreateAsync(AnswerModel model);
        Task<List<AnswerModel>> GetAllAsync(int? offset, int? limit);
        Task<AnswerModel> GetByIdAsync(Guid id);
        Task UpdateAsync(AnswerModel model);
        Task DeleteAsync(Guid id);
    }
}
