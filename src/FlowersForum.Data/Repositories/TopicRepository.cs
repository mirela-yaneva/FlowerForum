using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data.Repositories
{
    public class TopicRepository : BaseRepository<Topic, TopicEntity>, ITopicRepository
    {
        public TopicRepository(FlowersForumDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
