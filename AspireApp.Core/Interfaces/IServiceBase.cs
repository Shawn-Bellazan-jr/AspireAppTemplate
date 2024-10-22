using AspireApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Interfaces
{
    public interface IServiceBase<T>: IGenericBase<T> where T : EntityBase
    {


    }
}
