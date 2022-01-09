﻿using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Section, SectionEntity>().ReverseMap();
            CreateMap<RuleSection, RuleSectionEntity>().ReverseMap();
            CreateMap<Answer, AnswerEntity>().ReverseMap();
            CreateMap<Topic, TopicEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
