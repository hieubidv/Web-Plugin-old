﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Domain;
namespace ICreative.Model
{
    public interface IPermissionRepository : IRepository<Permission, System.Int32>
    {
    }

}
