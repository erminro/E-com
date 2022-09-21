using AutoMapper;
using InernshipApplication.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Dto.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDto>();
            CreateMap<User,NewUserDto>();
            CreateMap<NewUserDto, User>();
            CreateMap<UserDto, User>();
        }
    }
}
