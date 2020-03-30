
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Repositories
{
    public class PosMerchantRepository : Repository<PosMerchant, System.Int32>, IPosMerchantRepository
    {
        public PosMerchantRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }

}
