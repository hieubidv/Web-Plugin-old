

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosReceiptOfTestingMap : ClassMap<PosReceiptOfTesting>
	{
		public PosReceiptOfTestingMap()
		{
			Table("[PosReceiptOfTesting]");
            
		    Id(u => u.Id,"ReceiptOfTestingId").GeneratedBy.Identity().Not.Nullable();
                                                                      ;      
		    Map(u => u.TestDate).Not.Nullable();  
		    Map(u => u.AgentAName).Not.Nullable();  
		    Map(u => u.AgentBName).Not.Nullable();  
		    Map(u => u.PosId).Not.Nullable();  
            HasManyToMany(u => u.PosTerminals).Table("[PosTerminalReceiptOfTesting]").ParentKeyColumn("ReceiptOfTestingId").ChildKeyColumn("TerminalId");             
            References(u => u.PosMerchant).Column("MerchantId"); 
		}
	}
}
 
         

