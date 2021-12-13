using AutoMapper;
using FlowersForum.Api.Models;
using FlowersForum.Domain.Models;

namespace FlowersForum.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SectionModel, SectionVM>().ReverseMap();
            CreateMap<RuleSectionModel, RuleSectionVM>().ReverseMap();
            CreateMap<AnswerModel, AnswerVM>().ReverseMap();
            CreateMap<TopicModel, TopicVM>().ReverseMap();
        }
    }
}
