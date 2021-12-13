using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data.Repositories
{
    public class AnsweRepository : BaseRepository<AnswerModel, Answer>, IAnswerRepository
    {
        public AnsweRepository(FlowersForumDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
