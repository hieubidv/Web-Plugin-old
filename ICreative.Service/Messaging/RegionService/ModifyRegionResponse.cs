﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
using ICreative.Infrastructure.Domain;
namespace ICreative.Services.Messaging
{
    public class ModifyRegionResponse
    {
             // public RegionView Region { get; set; }
               public List<BusinessRule> Errors { get; set; }
    }
}
