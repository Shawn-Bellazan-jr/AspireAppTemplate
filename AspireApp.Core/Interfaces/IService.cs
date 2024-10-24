using AspireApp.Core.Abstracts;
using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Interfaces
{
    public interface IService<TDto, T>: IGenericBase<TDto>
        where TDto : class
        where T : EntityBase
    {

        Task UpdateAsync(string id, TDto type);

    }
}
