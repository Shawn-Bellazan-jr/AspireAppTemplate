using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Abstracts
{
    public abstract class EntityBase
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
