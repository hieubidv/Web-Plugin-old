
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
using ICreative.Services.Interfaces;
using ICreative.Services.Mapping;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public ProductService(IProductRepository productRepository,
                               IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            CreateProductResponse response = new CreateProductResponse();
            Product product = new Product();

                  product.ProductName = request.ProductName;	
                  product.QuantityPerUnit = request.QuantityPerUnit;	
                  product.UnitPrice = request.UnitPrice;	
                  product.UnitsInStock = request.UnitsInStock;	
                  product.UnitsOnOrder = request.UnitsOnOrder;	
                  product.ReorderLevel = request.ReorderLevel;	
                  product.Discontinued = request.Discontinued;	
                  product.Orders = request.Orders.ConvertToOrders();   
                  product.Category = request.Category.ConvertToCategory();                  
                  product.Supplier = request.Supplier.ConvertToSupplier();                  

            if (product.GetBrokenRules().Count() > 0)
            {
                response.Errors = product.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _productRepository.Add(product);
	            _uow.Commit();  
                    response.Errors = new List<BusinessRule>();
               } catch (Exception ex)
               {
                    List<BusinessRule> errors = new List<BusinessRule>();                    
                    do
                    {
                            errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                            ex = ex.InnerException;
                    } while (ex != null);

                    response.Errors = errors;
               }
            } 

            return response;
        }


        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();

            Product product = _productRepository
                                     .FindBy(request.ProductID);

            if (product != null)
            {
                response.ProductFound = true;
                response.Product = product.ConvertToProductView();
            }
            else
                response.ProductFound = false;


            return response;
        }

        public ModifyProductResponse ModifyProduct(ModifyProductRequest request)
        {
            ModifyProductResponse response = new ModifyProductResponse();

            Product product = _productRepository
                                         .FindBy(request.ProductID);

               product.Id = request.ProductID;
                  product.ProductName = request.ProductName;	
                  product.QuantityPerUnit = request.QuantityPerUnit;	
                  product.UnitPrice = request.UnitPrice;	
                  product.UnitsInStock = request.UnitsInStock;	
                  product.UnitsOnOrder = request.UnitsOnOrder;	
                  product.ReorderLevel = request.ReorderLevel;	
                  product.Discontinued = request.Discontinued;	
                  product.Orders = request.Orders.ConvertToOrders();   
                  product.Category = request.Category.ConvertToCategory();                  
                  product.Supplier = request.Supplier.ConvertToSupplier();                  


            if (product.GetBrokenRules().Count() > 0)
            {
                response.Errors = product.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _productRepository.Save(product);
        	        _uow.Commit();
                        response.Errors = new List<BusinessRule>();
                } catch (Exception ex)
                {
	            response.Errors = new List<BusinessRule>();
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                }                           
            }           


            return response;
        }
        
        public GetAllProductResponse GetAllProducts()
        {
            GetAllProductResponse response = new GetAllProductResponse();

            IEnumerable<Product> products = _productRepository
                                     .FindAll();

            if (products != null)
            {
                response.ProductFound = true;
                response.Products = products.ConvertToProductViews();   
            }
            else
                response.ProductFound = false;


            return response;
        } 
        
        
        public RemoveProductResponse RemoveProduct(RemoveProductRequest request)
        {
            RemoveProductResponse response = new RemoveProductResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_productRepository.Remove(request.ProductID) > 0)
	            {
        	        response.ProductDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
