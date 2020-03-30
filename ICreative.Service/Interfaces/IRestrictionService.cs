
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IRestrictionService
    {
        CreateRestrictionResponse CreateRestriction(CreateRestrictionRequest request);
        GetRestrictionResponse GetRestriction(GetRestrictionRequest request);
        GetAllRestrictionResponse GetAllRestrictions();
        ModifyRestrictionResponse ModifyRestriction(ModifyRestrictionRequest request);
        RemoveRestrictionResponse RemoveRestriction(RemoveRestrictionRequest request);
    }

}
