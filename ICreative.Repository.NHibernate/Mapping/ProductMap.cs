

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class ProductMap : ClassMap<Product>
	{
		public ProductMap()
		{
			Table("[Products]");
            
		    Id(u => u.Id,"ProductID").GeneratedBy.Identity().Not.Nullable();
                                                                                                              ;      
		    Map(u => u.ProductName).Not.Nullable();  
		    Map(u => u.QuantityPerUnit);  
		    Map(u => u.UnitPrice);  
		    Map(u => u.UnitsInStock);  
		    Map(u => u.UnitsOnOrder);  
		    Map(u => u.ReorderLevel);  
		    Map(u => u.Discontinued).Not.Nullable();  
            HasManyToMany(u => u.Orders).Table("[Order Details]").ParentKeyColumn("ProductID").ChildKeyColumn("OrderID");             
            References(u => u.Category).Column("CategoryID"); 
            References(u => u.Supplier).Column("SupplierID"); 
		}
	}
}
 
         

