

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class TerritoryMap : ClassMap<Territory>
	{
		public TerritoryMap()
		{
			Table("[Territories]");
            
            Id(u => u.Id,"TerritoryID").Not.Nullable();
                                        ;      
		    Map(u => u.TerritoryDescription).Not.Nullable();  
            HasManyToMany(u => u.Employees).Table("[EmployeeTerritories]").ParentKeyColumn("TerritoryID").ChildKeyColumn("EmployeeID");             
            References(u => u.Region).Column("RegionID"); 
		}
	}
}
 
         

