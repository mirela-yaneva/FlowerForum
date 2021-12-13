﻿using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;


namespace FlowersForum.Data.Repositories
{
    public class SectionRepository : BaseRepository<SectionModel, Section>, ISectionRepository
    {
        public SectionRepository(FlowersForumDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
