﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICreative.Services.ViewModels;
using ICreative.Infrastructure.Domain;
namespace ICreative.Services.Messaging
{
    public class RemoveUserResponse
    {
        public bool UserDeleted { get; set; }
        public List<BusinessRule> Errors { get; set; }
    }
}
