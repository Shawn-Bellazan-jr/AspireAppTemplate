using AspireApp.Core.Abstracts;
using AspireApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Interfaces.Common
{
    public interface IGenericDelete<T>
    {
        Task DeleteAsync(string id);
    }
}
