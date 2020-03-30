
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IProductService
    {
        CreateProductResponse CreateProduct(CreateProductRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
        GetAllProductResponse GetAllProducts();
        ModifyProductResponse ModifyProduct(ModifyProductRequest request);
        RemoveProductResponse RemoveProduct(RemoveProductRequest request);
    }

}
