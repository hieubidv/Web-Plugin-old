

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosReceiptOfDeliveryMap : ClassMap<PosReceiptOfDelivery>
	{
		public PosReceiptOfDeliveryMap()
		{
			Table("[PosReceiptOfDelivery]");
            
		    Id(u => u.Id,"PosReceiptOfDeliveryId").GeneratedBy.Identity().Not.Nullable();
                                                  ;      
		    Map(u => u.DeliveryDate).Not.Nullable();  
		    Map(u => u.ReceiverName).Not.Nullable();  
            HasManyToMany(u => u.PosTerminals).Table("[PosReceiptOfDeliveriesToPosTerminals]").ParentKeyColumn("ReceiptOfDeliveryId").ChildKeyColumn("TerminalId");             
            References(u => u.User).Column("DeliverId"); 
		}
	}
}
 
         

