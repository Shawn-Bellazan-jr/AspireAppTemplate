using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
       
    }
}
