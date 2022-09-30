using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Users.Commands.CreateUser;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreatedUserDto>().ReverseMap();
            CreateMap<User, UpdatedUserDto>().ReverseMap();
            CreateMap<User, DeletedUserDto>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, GetByEmailUserDto>().ReverseMap();
            CreateMap<User, GetByIdUserDto>().ReverseMap();
        }
    }
}
