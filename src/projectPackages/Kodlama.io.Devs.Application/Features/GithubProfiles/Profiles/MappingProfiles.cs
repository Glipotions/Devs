using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Create
            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();

            // Update
            CreateMap<GithubProfile, UpdateGithubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile, UpdatedGithubProfileDto>().ReverseMap();

            // Delete
            CreateMap<GithubProfile, DeleteGithubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();

            // get list
            CreateMap<GithubProfileListModel, IPaginate<GithubProfile>>().ReverseMap();
            CreateMap<GithubProfile, GithubProfileListDto>()
                .ForMember(dest => dest.DeveloperFullName, src =>
                    src.MapFrom(c => c.User.FirstName + " " + c.User.LastName)).ReverseMap();
        }
    }
}
