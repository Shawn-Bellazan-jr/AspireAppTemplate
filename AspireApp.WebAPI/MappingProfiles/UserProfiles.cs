using AspireApp.Core.Entities;
using AspireApp.WebAPI.Models;
using AutoMapper;

namespace AspireApp.WebAPI.MappingProfiles
{
    public class UserProfiles: Profile
    {
        public UserProfiles()
        {
            // Map between User and UserDto in both directions
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
