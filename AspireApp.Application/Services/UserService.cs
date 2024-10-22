using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;


namespace AspireApp.Application.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IRepositoryBase<User> repository) : base(repository)
        {
        }
    }
}
