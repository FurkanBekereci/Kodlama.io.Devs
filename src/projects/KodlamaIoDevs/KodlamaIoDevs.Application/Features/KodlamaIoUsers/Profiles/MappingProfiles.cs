using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.CreateKodlamaIoUser;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<KodlamaIoUser,CreateKodlamaIoUserCommand>().ReverseMap();
            CreateMap<KodlamaIoUser,CreatedKodlamaIoUserDto>().ReverseMap();
            CreateMap<KodlamaIoUser,UpdatedKodlamaIoUserDto>().ReverseMap();
            CreateMap<KodlamaIoUser,DeletedKodlamaIoUserDto>().ReverseMap();
            CreateMap<KodlamaIoUser,KodlamaIoUserGetByIdDto>().ReverseMap();
            CreateMap<KodlamaIoUser,KodlamaIoUserGetByIdGithubUrlDto>().ReverseMap();
            CreateMap<KodlamaIoUser,KodlamaIoUserGetByUserIdDto>().ReverseMap();
            CreateMap<IPaginate<KodlamaIoUser>,KodlamaIoUserListModel>().ReverseMap();
            CreateMap<KodlamaIoUser,KodlamaIoUserListDto>().ReverseMap();
        }
    }
}
