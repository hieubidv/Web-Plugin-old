

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class CategoryMap : ClassMap<Category>
	{
		public CategoryMap()
		{
			Table("[Categories]");
            
		    Id(u => u.Id,"CategoryID").GeneratedBy.Identity().Not.Nullable();
                                                  ;      
		    Map(u => u.CategoryName).Not.Nullable();  
		    Map(u => u.Description);  
		    Map(u => u.Picture).CustomSqlType("varbinary(max)").Length(int.MaxValue);  
             HasMany(u => u.Products).KeyColumn("CategoryID");            
		}
	}
}
 
         

