﻿using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Domain.Entities
{
    public class JobType : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Details { get; set; }
    }
}