

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class MenuItemMap : ClassMap<MenuItem>
	{
		public MenuItemMap()
		{
			Table("[MenuItem]");
            
		    Id(u => u.Id,"MenuItemId").GeneratedBy.Identity().Not.Nullable();
                                        ;      
		    Map(u => u.MenuItemName).Not.Nullable();  
		    Map(u => u.ParentId).Not.Nullable();  
		    Map(u => u.MenuItemUrl).Not.Nullable();  
		}
	}
}
 
         

