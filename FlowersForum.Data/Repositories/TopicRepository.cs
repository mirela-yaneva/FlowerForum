using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data.Repositories
{
    public class TopicRepository : BaseRepository<TopicModel, Topic>, ITopicRepository
    {
        public TopicRepository(FlowersForumDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
