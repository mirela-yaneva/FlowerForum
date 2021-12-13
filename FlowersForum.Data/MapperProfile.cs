using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Models;

namespace FlowersForum.Data
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SectionModel, Section>().ReverseMap();
            CreateMap<RuleSectionModel, RuleSection>().ReverseMap();
            CreateMap<AnswerModel, Answer>().ReverseMap();
            CreateMap<TopicModel, Topic>().ReverseMap();
        }
    }
}
