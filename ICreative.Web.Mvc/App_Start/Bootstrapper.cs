
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ICreative.Controllers;
using ICreative.Infrastructure;
using ICreative.Infrastructure.Authentication;
using ICreative.Services.Interfaces;
using ICreative.Services.Implementations;
using ICreative.Repository.NHibernate.Repositories;
using ICreative.Repository.NHibernate;
using ICreative.Model;
namespace ICreative.Web.Mvc
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFormsAuthentication, DBFormAuthentication>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<ISecurityApplicationService<Guid>, SecurityApplicationService>();
            container.RegisterType<ICreative.Infrastructure.UnitOfWork.IUnitOfWork, NHUnitOfWork>();
            container.RegisterType<IPosDeviceService, PosDeviceService>();
            container.RegisterType<IPosDeviceRepository, PosDeviceRepository>();    
            container.RegisterType<IPosAddressService, PosAddressService>();
            container.RegisterType<IPosAddressRepository, PosAddressRepository>();    
            container.RegisterType<IPosStatusTerminalService, PosStatusTerminalService>();
            container.RegisterType<IPosStatusTerminalRepository, PosStatusTerminalRepository>();    
            container.RegisterType<IPosStatusSimService, PosStatusSimService>();
            container.RegisterType<IPosStatusSimRepository, PosStatusSimRepository>();    
            container.RegisterType<IPosSimProviderService, PosSimProviderService>();
            container.RegisterType<IPosSimProviderRepository, PosSimProviderRepository>();    
            container.RegisterType<IPosMerchantService, PosMerchantService>();
            container.RegisterType<IPosMerchantRepository, PosMerchantRepository>();    
            container.RegisterType<IPosSimService, PosSimService>();
            container.RegisterType<IPosSimRepository, PosSimRepository>();    
            container.RegisterType<IPosReceiptOfTestingService, PosReceiptOfTestingService>();
            container.RegisterType<IPosReceiptOfTestingRepository, PosReceiptOfTestingRepository>();    
            container.RegisterType<IPosReceiptOfDeliveryService, PosReceiptOfDeliveryService>();
            container.RegisterType<IPosReceiptOfDeliveryRepository, PosReceiptOfDeliveryRepository>();    
            container.RegisterType<IPosTerminalService, PosTerminalService>();
            container.RegisterType<IPosTerminalRepository, PosTerminalRepository>();    
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();    
            container.RegisterType<IMenuItemService, MenuItemService>();
            container.RegisterType<IMenuItemRepository, MenuItemRepository>();    
            container.RegisterType<IPermissionService, PermissionService>();
            container.RegisterType<IPermissionRepository, PermissionRepository>();    
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();    
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();    
            container.RegisterType<ICustomerDemographicService, CustomerDemographicService>();
            container.RegisterType<ICustomerDemographicRepository, CustomerDemographicRepository>();    
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IRoleRepository, RoleRepository>();    
            container.RegisterType<IRestrictionService, RestrictionService>();
            container.RegisterType<IRestrictionRepository, RestrictionRepository>();    
            container.RegisterType<IRegionService, RegionService>();
            container.RegisterType<IRegionRepository, RegionRepository>();    
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();    
            container.RegisterType<IShipperService, ShipperService>();
            container.RegisterType<IShipperRepository, ShipperRepository>();    
            container.RegisterType<IRoomService, RoomService>();
            container.RegisterType<IRoomRepository, RoomRepository>();    
            container.RegisterType<ITerritoryService, TerritoryService>();
            container.RegisterType<ITerritoryRepository, TerritoryRepository>();    
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();    
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepository, OrderRepository>();    
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();    

            //container.RegisterType(typeof(IRepository<>), typeof(EFRepository<>), new InjectionConstructor(new MembershipContext()));
            //container.RegisterType(typeof(IEntityRepository<>), typeof(EntityRepository<>), new InjectionConstructor(new DocumentContext()));
            //container.RegisterType<IFormsAuthentication, LdapFormsAuthentication>(new InjectionConstructor(new EFRepository<User>(new MembershipContext())));
        }
    }

}