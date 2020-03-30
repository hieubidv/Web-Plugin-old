
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _uow;

        public OrderService(IOrderRepository orderRepository,
                               IUnitOfWork uow)
        {
            _orderRepository = orderRepository;
            _uow = uow;
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            Order order = new Order();

                  order.OrderDate = request.OrderDate;	
                  order.RequiredDate = request.RequiredDate;	
                  order.ShippedDate = request.ShippedDate;	
                  order.Freight = request.Freight;	
                  order.ShipName = request.ShipName;	
                  order.ShipAddress = request.ShipAddress;	
                  order.ShipCity = request.ShipCity;	
                  order.ShipRegion = request.ShipRegion;	
                  order.ShipPostalCode = request.ShipPostalCode;	
                  order.ShipCountry = request.ShipCountry;	
                  order.Products = request.Products.ConvertToProducts();   
                  order.Employee = request.Employee.ConvertToEmployee();                  
                  order.Customer = request.Customer.ConvertToCustomer();                  
                  order.Shipper = request.Shipper.ConvertToShipper();                  

            if (order.GetBrokenRules().Count() > 0)
            {
                response.Errors = order.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _orderRepository.Add(order);
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


        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            GetOrderResponse response = new GetOrderResponse();

            Order order = _orderRepository
                                     .FindBy(request.OrderID);

            if (order != null)
            {
                response.OrderFound = true;
                response.Order = order.ConvertToOrderView();
            }
            else
                response.OrderFound = false;


            return response;
        }

        public ModifyOrderResponse ModifyOrder(ModifyOrderRequest request)
        {
            ModifyOrderResponse response = new ModifyOrderResponse();

            Order order = _orderRepository
                                         .FindBy(request.OrderID);

               order.Id = request.OrderID;
                  order.OrderDate = request.OrderDate;	
                  order.RequiredDate = request.RequiredDate;	
                  order.ShippedDate = request.ShippedDate;	
                  order.Freight = request.Freight;	
                  order.ShipName = request.ShipName;	
                  order.ShipAddress = request.ShipAddress;	
                  order.ShipCity = request.ShipCity;	
                  order.ShipRegion = request.ShipRegion;	
                  order.ShipPostalCode = request.ShipPostalCode;	
                  order.ShipCountry = request.ShipCountry;	
                  order.Products = request.Products.ConvertToProducts();   
                  order.Employee = request.Employee.ConvertToEmployee();                  
                  order.Customer = request.Customer.ConvertToCustomer();                  
                  order.Shipper = request.Shipper.ConvertToShipper();                  


            if (order.GetBrokenRules().Count() > 0)
            {
                response.Errors = order.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _orderRepository.Save(order);
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
        
        public GetAllOrderResponse GetAllOrders()
        {
            GetAllOrderResponse response = new GetAllOrderResponse();

            IEnumerable<Order> orders = _orderRepository
                                     .FindAll();

            if (orders != null)
            {
                response.OrderFound = true;
                response.Orders = orders.ConvertToOrderViews();   
            }
            else
                response.OrderFound = false;


            return response;
        } 
        
        
        public RemoveOrderResponse RemoveOrder(RemoveOrderRequest request)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_orderRepository.Remove(request.OrderID) > 0)
	            {
        	        response.OrderDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
