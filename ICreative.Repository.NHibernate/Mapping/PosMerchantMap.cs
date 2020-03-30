

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosMerchantMap : ClassMap<PosMerchant>
	{
		public PosMerchantMap()
		{
			Table("[PosMerchant]");
            
		    Id(u => u.Id,"MerchantId").GeneratedBy.Identity().Not.Nullable();
                                                                      ;      
		    Map(u => u.MerchantName).Not.Nullable();  
		    Map(u => u.BusinessName).Not.Nullable();  
		    Map(u => u.BannerName).Not.Nullable();  
		    Map(u => u.MerchantIdByHeadQuater).Not.Nullable();  
             HasMany(u => u.PosReceiptOfTestings).KeyColumn("MerchantId");            
            References(u => u.PosAddress).Column("AddressId"); 
		}
	}
}
 
         

