using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.Infrastructure.Interfaces;
using AspireApp.WebAPI.Models;


namespace AspireApp.Application.Services
{
    public class UserService : ServiceBase<UserDto,User>, IUserService
    {
    }
}
