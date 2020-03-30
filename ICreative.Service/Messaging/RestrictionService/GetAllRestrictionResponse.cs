
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllRestrictionResponse
    {
              public bool RestrictionFound { get; set; }
              public IEnumerable<RestrictionView> Restrictions { get; set; }
    }
}
