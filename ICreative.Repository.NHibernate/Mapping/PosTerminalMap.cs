

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosTerminalMap : ClassMap<PosTerminal>
	{
		public PosTerminalMap()
		{
			Table("[PosTerminal]");
            
		    Id(u => u.Id,"TerminalId").GeneratedBy.Identity().Not.Nullable();
                                                                                          ;      
		    Map(u => u.TerminalIdByHeadQuater).Not.Nullable();  
		    Map(u => u.InitializeCode).Not.Nullable();  
		    Map(u => u.ConnectType).Not.Nullable();  
            HasManyToMany(u => u.PosReceiptOfDeliveries).Table("[PosReceiptOfDeliveriesToPosTerminals]").ParentKeyColumn("TerminalId").ChildKeyColumn("ReceiptOfDeliveryId");             
            HasManyToMany(u => u.PosReceiptOfTestings).Table("[PosTerminalReceiptOfTesting]").ParentKeyColumn("TerminalId").ChildKeyColumn("ReceiptOfTestingId");             
            References(u => u.PosDevice).Column("DeviceId"); 
            References(u => u.PosStatusTerminal).Column("TerminalStatusId"); 
            References(u => u.PosSim).Column("SimId"); 
		}
	}
}
 
         

