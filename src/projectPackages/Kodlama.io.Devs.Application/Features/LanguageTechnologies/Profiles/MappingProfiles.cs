using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            /// Reverse Map: hep normal hem tersi maplemeyi sağlar.
            CreateMap<LanguageTechnology, CreateLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ReverseMap();
            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyGetByIdDto>().ReverseMap();
        }
    }
}
