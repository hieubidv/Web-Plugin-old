
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface ISupplierService
    {
        CreateSupplierResponse CreateSupplier(CreateSupplierRequest request);
        GetSupplierResponse GetSupplier(GetSupplierRequest request);
        GetAllSupplierResponse GetAllSuppliers();
        ModifySupplierResponse ModifySupplier(ModifySupplierRequest request);
        RemoveSupplierResponse RemoveSupplier(RemoveSupplierRequest request);
    }

}
