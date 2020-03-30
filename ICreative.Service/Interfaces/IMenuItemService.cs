
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IMenuItemService
    {
        CreateMenuItemResponse CreateMenuItem(CreateMenuItemRequest request);
        GetMenuItemResponse GetMenuItem(GetMenuItemRequest request);
        GetAllMenuItemResponse GetAllMenuItems();
        ModifyMenuItemResponse ModifyMenuItem(ModifyMenuItemRequest request);
        RemoveMenuItemResponse RemoveMenuItem(RemoveMenuItemRequest request);
    }

}
