using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data.Repositories
{
    public class RuleSectionRepository : BaseRepository<RuleSection, RuleSectionEntity>, IRuleSectionRepository
    {
        public RuleSectionRepository(FlowersForumDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
