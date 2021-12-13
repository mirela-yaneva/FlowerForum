using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data.Repositories
{
    public class RuleSectionRepository : BaseRepository<RuleSectionModel, RuleSection>, IRuleSectionRepository
    {
        public RuleSectionRepository(FlowersForumDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
