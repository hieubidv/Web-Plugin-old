

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosStatusTerminalMap : ClassMap<PosStatusTerminal>
	{
		public PosStatusTerminalMap()
		{
			Table("[PosStatusTerminal]");
            
		    Id(u => u.Id,"TerminalStatusId").GeneratedBy.Identity().Not.Nullable();
                              ;      
		    Map(u => u.StatusName).Not.Nullable();  
             HasMany(u => u.PosTerminals).KeyColumn("TerminalStatusId");            
		}
	}
}
 
         

