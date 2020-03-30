
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;
namespace ICreative.Services
{
    public class AutoMapperBootStrapper
    {
        private static MapperConfigurationExpression _configuration;
        public static MapperConfigurationExpression Configuation
        {
            get { if (_configuration == null)
                   {
                    _configuration =  new MapperConfigurationExpression();                       
                   }
                return _configuration;
            }
        }
    
        public static void ServiceMap()
        {
                Configuation.CreateMap<PosDevice, PosDeviceView>().ForMember(u => u.DeviceId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosDeviceView, PosDevice>().ForMember(u => u.Id, x => x.MapFrom(src => src.DeviceId)).MaxDepth(3);     
                Configuation.CreateMap<PosAddress, PosAddressView>().ForMember(u => u.AddressId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosAddressView, PosAddress>().ForMember(u => u.Id, x => x.MapFrom(src => src.AddressId)).MaxDepth(3);     
                Configuation.CreateMap<PosStatusTerminal, PosStatusTerminalView>().ForMember(u => u.TerminalStatusId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosStatusTerminalView, PosStatusTerminal>().ForMember(u => u.Id, x => x.MapFrom(src => src.TerminalStatusId)).MaxDepth(3);     
                Configuation.CreateMap<PosStatusSim, PosStatusSimView>().ForMember(u => u.StatusId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosStatusSimView, PosStatusSim>().ForMember(u => u.Id, x => x.MapFrom(src => src.StatusId)).MaxDepth(3);     
                Configuation.CreateMap<PosSimProvider, PosSimProviderView>().ForMember(u => u.SimProviderId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosSimProviderView, PosSimProvider>().ForMember(u => u.Id, x => x.MapFrom(src => src.SimProviderId)).MaxDepth(3);     
                Configuation.CreateMap<PosMerchant, PosMerchantView>().ForMember(u => u.MerchantId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosMerchantView, PosMerchant>().ForMember(u => u.Id, x => x.MapFrom(src => src.MerchantId)).MaxDepth(3);     
                Configuation.CreateMap<PosSim, PosSimView>().ForMember(u => u.SimId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosSimView, PosSim>().ForMember(u => u.Id, x => x.MapFrom(src => src.SimId)).MaxDepth(3);     
                Configuation.CreateMap<PosReceiptOfTesting, PosReceiptOfTestingView>().ForMember(u => u.ReceiptOfTestingId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosReceiptOfTestingView, PosReceiptOfTesting>().ForMember(u => u.Id, x => x.MapFrom(src => src.ReceiptOfTestingId)).MaxDepth(3);     
                Configuation.CreateMap<PosReceiptOfDelivery, PosReceiptOfDeliveryView>().ForMember(u => u.PosReceiptOfDeliveryId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosReceiptOfDeliveryView, PosReceiptOfDelivery>().ForMember(u => u.Id, x => x.MapFrom(src => src.PosReceiptOfDeliveryId)).MaxDepth(3);     
                Configuation.CreateMap<PosTerminal, PosTerminalView>().ForMember(u => u.TerminalId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PosTerminalView, PosTerminal>().ForMember(u => u.Id, x => x.MapFrom(src => src.TerminalId)).MaxDepth(3);     
                Configuation.CreateMap<Category, CategoryView>().ForMember(u => u.CategoryID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<CategoryView, Category>().ForMember(u => u.Id, x => x.MapFrom(src => src.CategoryID)).MaxDepth(3);     
                Configuation.CreateMap<MenuItem, MenuItemView>().ForMember(u => u.MenuItemId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<MenuItemView, MenuItem>().ForMember(u => u.Id, x => x.MapFrom(src => src.MenuItemId)).MaxDepth(3);     
                Configuation.CreateMap<Permission, PermissionView>().ForMember(u => u.PermissionId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<PermissionView, Permission>().ForMember(u => u.Id, x => x.MapFrom(src => src.PermissionId)).MaxDepth(3);     
                Configuation.CreateMap<Employee, EmployeeView>().ForMember(u => u.EmployeeID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<EmployeeView, Employee>().ForMember(u => u.Id, x => x.MapFrom(src => src.EmployeeID)).MaxDepth(3);     
                Configuation.CreateMap<Customer, CustomerView>().ForMember(u => u.CustomerID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<CustomerView, Customer>().ForMember(u => u.Id, x => x.MapFrom(src => src.CustomerID)).MaxDepth(3);     
                Configuation.CreateMap<CustomerDemographic, CustomerDemographicView>().ForMember(u => u.CustomerTypeID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<CustomerDemographicView, CustomerDemographic>().ForMember(u => u.Id, x => x.MapFrom(src => src.CustomerTypeID)).MaxDepth(3);     
                Configuation.CreateMap<Role, RoleView>().ForMember(u => u.RoleId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<RoleView, Role>().ForMember(u => u.Id, x => x.MapFrom(src => src.RoleId)).MaxDepth(3);     
                Configuation.CreateMap<Restriction, RestrictionView>().ForMember(u => u.RestrictionId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<RestrictionView, Restriction>().ForMember(u => u.Id, x => x.MapFrom(src => src.RestrictionId)).MaxDepth(3);     
                Configuation.CreateMap<Region, RegionView>().ForMember(u => u.RegionID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<RegionView, Region>().ForMember(u => u.Id, x => x.MapFrom(src => src.RegionID)).MaxDepth(3);     
                Configuation.CreateMap<Supplier, SupplierView>().ForMember(u => u.SupplierID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<SupplierView, Supplier>().ForMember(u => u.Id, x => x.MapFrom(src => src.SupplierID)).MaxDepth(3);     
                Configuation.CreateMap<Shipper, ShipperView>().ForMember(u => u.ShipperID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<ShipperView, Shipper>().ForMember(u => u.Id, x => x.MapFrom(src => src.ShipperID)).MaxDepth(3);     
                Configuation.CreateMap<Room, RoomView>().ForMember(u => u.RoomId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<RoomView, Room>().ForMember(u => u.Id, x => x.MapFrom(src => src.RoomId)).MaxDepth(3);     
                Configuation.CreateMap<Territory, TerritoryView>().ForMember(u => u.TerritoryID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<TerritoryView, Territory>().ForMember(u => u.Id, x => x.MapFrom(src => src.TerritoryID)).MaxDepth(3);     
                Configuation.CreateMap<Product, ProductView>().ForMember(u => u.ProductID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<ProductView, Product>().ForMember(u => u.Id, x => x.MapFrom(src => src.ProductID)).MaxDepth(3);     
                Configuation.CreateMap<Order, OrderView>().ForMember(u => u.OrderID, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<OrderView, Order>().ForMember(u => u.Id, x => x.MapFrom(src => src.OrderID)).MaxDepth(3);     
                Configuation.CreateMap<User, UserView>().ForMember(u => u.UserId, x => x.MapFrom(src => src.Id)).MaxDepth(3);     
                Configuation.CreateMap<UserView, User>().ForMember(u => u.Id, x => x.MapFrom(src => src.UserId)).MaxDepth(3);     
        }
    
        public static void Init()
        {
            Mapper.Initialize(Configuation);
        }
    }
}
