using AutoMapper;
using FlowersForum.Api.Models;
using FlowersForum.Domain.Models;

namespace FlowersForum.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Section, SectionVM>().ReverseMap();
            CreateMap<RuleSection, RuleSectionVM>().ReverseMap();
            CreateMap<Answer, AnswerVM>().ReverseMap();
            CreateMap<Topic, TopicVM>().ReverseMap();
        }
    }
}
