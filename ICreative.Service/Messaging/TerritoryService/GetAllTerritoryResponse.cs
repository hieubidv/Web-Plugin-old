
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllTerritoryResponse
    {
              public bool TerritoryFound { get; set; }
              public IEnumerable<TerritoryView> Territories { get; set; }
    }
}
