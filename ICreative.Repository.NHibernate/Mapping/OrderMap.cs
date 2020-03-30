

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class OrderMap : ClassMap<Order>
	{
		public OrderMap()
		{
			Table("[Orders]");
            
		    Id(u => u.Id,"OrderID").GeneratedBy.Identity().Not.Nullable();
                                                                                                                                                      ;      
		    Map(u => u.OrderDate);  
		    Map(u => u.RequiredDate);  
		    Map(u => u.ShippedDate);  
		    Map(u => u.Freight);  
		    Map(u => u.ShipName);  
		    Map(u => u.ShipAddress);  
		    Map(u => u.ShipCity);  
		    Map(u => u.ShipRegion);  
		    Map(u => u.ShipPostalCode);  
		    Map(u => u.ShipCountry);  
            HasManyToMany(u => u.Products).Table("[Order Details]").ParentKeyColumn("OrderID").ChildKeyColumn("ProductID");             
            References(u => u.Employee).Column("EmployeeID"); 
            References(u => u.Customer).Column("CustomerID"); 
            References(u => u.Shipper).Column("ShipVia"); 
		}
	}
}
 
         

