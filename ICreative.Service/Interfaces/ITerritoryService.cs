
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface ITerritoryService
    {
        CreateTerritoryResponse CreateTerritory(CreateTerritoryRequest request);
        GetTerritoryResponse GetTerritory(GetTerritoryRequest request);
        GetAllTerritoryResponse GetAllTerritories();
        ModifyTerritoryResponse ModifyTerritory(ModifyTerritoryRequest request);
        RemoveTerritoryResponse RemoveTerritory(RemoveTerritoryRequest request);
    }

}
