using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.Infrastructure.Interfaces;
using AspireApp.WebAPI.Models;
using AutoMapper;


namespace AspireApp.Application.Services
{
    public class UserService : ServiceBase<UserDto, User>, IUserService
    {
        public UserService(IUnitOfWork<User> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
