using AspireApp.Core.Entities;
using AspireApp.WebAPI.Models;
using AutoMapper;

namespace AspireApp.WebAPI.MappingProfiles
{
    public class UserProfiles: Profile
    {
        public UserProfiles()
        {
            // Map UserDto to User (and vice versa)
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
