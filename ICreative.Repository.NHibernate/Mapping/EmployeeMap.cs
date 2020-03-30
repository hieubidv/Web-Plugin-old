

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class EmployeeMap : ClassMap<Employee>
	{
		public EmployeeMap()
		{
			Table("[Employees]");
            
		    Id(u => u.Id,"EmployeeID").GeneratedBy.Identity().Not.Nullable();
                                                                                                                                                                                                        ;      
		    Map(u => u.LastName).Not.Nullable();  
		    Map(u => u.FirstName).Not.Nullable();  
		    Map(u => u.Title);  
		    Map(u => u.TitleOfCourtesy);  
		    Map(u => u.BirthDate);  
		    Map(u => u.HireDate);  
		    Map(u => u.Address);  
		    Map(u => u.City);  
		    Map(u => u.Region);  
		    Map(u => u.PostalCode);  
		    Map(u => u.Country);  
		    Map(u => u.HomePhone);  
		    Map(u => u.Extension);  
		    Map(u => u.Photo).CustomSqlType("varbinary(max)").Length(int.MaxValue);  
		    Map(u => u.Notes);  
		    Map(u => u.PhotoPath);  
            HasManyToMany(u => u.Territories).Table("[EmployeeTerritories]").ParentKeyColumn("EmployeeID").ChildKeyColumn("TerritoryID");             
             HasMany(u => u.Orders).KeyColumn("EmployeeID");            
            References(u => u.EmployeeReference).Column("ReportsTo"); 
		}
	}
}
 
         

