﻿using AspireApp.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Entities
{
    public class User: EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
