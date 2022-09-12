using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            /// Reverse Map: hep normal hem tersi maplemeyi sağlar.
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, UpdatedLanguageDto>().ReverseMap();
            CreateMap<Language, DeletedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
        }
    }
}
